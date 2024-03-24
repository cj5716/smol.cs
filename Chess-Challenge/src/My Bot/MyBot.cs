﻿// Project: smol.cs
// License: MIT
// Authors: Gediminas Masaitis, Goh CJ (cj5716)

using System;
using System.Collections.Generic;
using System.Linq;
using ChessChallenge.API;

public class MyBot : IChessBot
{
    // Transposition table
    // We store the results of previous searches, keeping track of the score at that position,
    // as well as specific things how it was searched:
    // 1. Did it go through all the search and fail to find a better move? (Upper limit flag)
    // 2. Did it cause a beta cutoff and stopped searching early (Lower limit flag)
    // 3. Did it search through all moves and find a new best move for the currently searched position (Exact flag)
    // Read more about it here: https://www.chessprogramming.org/Transposition_Table
    // Format: Position key, move, depth, score, flag
    (ulong, Move, int, int, byte)[] TT = new (ulong, Move, int, int, byte)[2097152];


    // Due to the rules of the challenge and how token counting works, evaluation constants are packed into C# decimals,
    // as they allow the most efficient (12 usable bits per token).
    // The ordering is as follows: Midgame term 1, endgame term 1, midgame, term 2, endgame term 2...
    static sbyte[] extracted = new [] { 4835740172228143389605888m, 2477126802417782031162277888m, 8987268064278214852567370499m, 10217997163295925037733585164m, 11160973432655769285841133323m, 15490188721000912996060636172m, 29756944731101898114373858066m, 35638477370265809412994327845m, 19342813114113316978950144m, 4029415944847360518751518720m, 9914528280548214173287845126m, 9295591374614011062820480010m, 9297990354729639866572414218m, 19514783056024713615916080651m, 31298343949203241391214116622m, 33160132234332197119198324513m, 8043016548800136891691039241m, 71819879314466714244163308032m }.SelectMany(x => decimal.GetBits(x).Take(3).SelectMany(y => (sbyte[])(Array)BitConverter.GetBytes(y))).ToArray();

    // After extracting the raw mindgame/endgame terms, we repack it into integers of midgame/endgame pairs.
    // The scheme in bytes (assuming little endian) is: 00 EG 00 MG
    // The idea of this is that we can do operations on both midgame and endgame values simultaneously, preventing the need
    // for evaluation for separate mid-game / end-game terms.
    int[] evalValues = Enumerable.Range(0, 108).Select(i => extracted[i * 2] | extracted[i * 2 + 1] << 16).ToArray();

    public Move Think(Board board, Timer timer)
    {
        // The move that will eventually be reported as our best move
        Move rootBestMove = default;

        // Intitialise parameters that exist only during one search
        var (allocatedTime, i, depth) = (timer.MillisecondsRemaining / 8, 0, 1);

        long nodes = 0; // #DEBUG

        // Negamax search is embedded as a local function in order to reduce token count
        int Search(bool root, int depth, int alpha, int beta)
        {
            // Repetition detection
            // There is no need to check for 3-fold repetition, if a single repetition (0 = draw) ends up being the best,
            // we can trust that repeating moves is the best course of action in this position.
            if (!root && board.IsRepeatedPosition())
                return 0;

            // In-qsearch is a flag that determines whether not we should prune positions ans whether or not to search non-captures.
            // Qsearch, also meaning quiescence search, is a mode that only looks at captures in order to give a more accurate
            // estimate "if all the viable captures happen". In this engine it is interlaced with the main search to save tokens, although
            // in most engines you will see a separate function for it.
            // -2000000 = -inf. It just indicates "no move has been found yet".
            // Tempo is the idea that each move is benefitial to us, so we adjust the static eval using a fixed value.
            // We use 15 tempo for evaluation for mid-game, 0 for end-game.
            var (key, inQsearch, bestScore, score, phase) = (board.ZobristKey, depth <= 0, -2_000_000, 15, 0);

            // Here we do a static evaluation to determine the current static score for the position.
            // A static evaluation is like a one-look determination of how good the position is, without looking into the future.
            // This is a tapered evaluation, meaning that each term has a midgame (or more accurately early-game) and end-game value.
            // After the evaluation is done, scores are interpolated according to phase values. Read more: https://www.chessprogramming.org/Tapered_Eval
            // This evaluation is similar to many other evaluations with some differences to save bytes.
            // It is tuned with a method called Texel Tuning using my project at https://github.com/GediminasMasaitis/texel-tuner
            // More info about Texel tuning at https://www.chessprogramming.org/Texel%27s_Tuning_Method,
            // and specifically the implementation in my tuner: https://github.com/AndyGrant/Ethereal/blob/master/Tuning.pdf
            // The evaluation is inlined into search to preserve bytes, and to keep some information (phase) around for later use.
            foreach (bool isWhite in new[] {!board.IsWhiteToMove, board.IsWhiteToMove})
            {
                score = -score;

                //       None (skipped)               King
                for (var pieceIndex = 0; ++pieceIndex <= 6;)
                {
                    var bitboard = board.GetPieceBitboard((PieceType)pieceIndex, isWhite);

                    // This and the following line is an efficient way to loop over each piece of a certain type.
                    // Instead of looping each square, we can skip empty squares by looking at a bitboard of each piece,
                    // and incrementally removing squares from it. More information: https://www.chessprogramming.org/Bitboards
                    while (bitboard != 0)
                    {
                        var sq = BitboardHelper.ClearAndGetIndexOfLSB(ref bitboard);

                        // For bishop, rook, queen and king. ELO tests proved that mobility for other pieces are not worth considering.
                        if (pieceIndex > 2)
                        {
                            // Mobility
                            // The more squares you are able to attack, the more flexible your position is.
                            var mobility = BitboardHelper.GetPieceAttacks((PieceType)pieceIndex, new (sq), board, isWhite) & ~(isWhite ? board.WhitePiecesBitboard : board.BlackPiecesBitboard);
                            score += evalValues[101 + pieceIndex] * BitboardHelper.GetNumberOfSetBits(mobility);
                        }

                        // Flip square if black.
                        // This is needed for piece square tables (PSTs), because they are always written from the side that is playing.
                        if (!isWhite) sq ^= 56;

                        // We count the phase of the current position.
                        // The phase represents how much we are into the end-game in a gradual way. 24 = all pieces on the board, 0 = only pawns/kings left.
                        // This is a core principle of tapered evaluation. We increment phase for each piece for both sides based on it's importance:
                        // None: 0 (obviously)
                        // Pawn: 0
                        // Knight: 1
                        // Bishop: 1
                        // Rook: 2
                        // Queen: 4
                        // King: 0 (because checkmate and stalemate has it's own special rules late on)
                        // These values are encoded in the decimals mentioned before and aren't explicit in the engine's code.
                        phase += evalValues[pieceIndex];

                        // Material and PSTs
                        // PST mean "piece-square tables", it is naturally better for a piece to be on a specific square.
                        // More: https://www.chessprogramming.org/Piece-Square_Tables
                        // In this engine, in order to save tokens, the concept of "material" has been removed.
                        // Instead, each square for each piece has a higher value adjusted to the type of piece that occupies it.
                        // In order to fit in 1 byte per row/column, the value of each row/column has been divided by 8,
                        // and here multiplied by 8 (<< 3 is equivalent but ends up 1 token smaller).
                        // Additionally, each column/row, or file/rank is evaluated, as opposed to every square individually,
                        // which is only ~20 ELO weaker compared to full PSTs and saves a lot of tokens.
                        score += evalValues[pieceIndex * 8 + sq / 8]
                               + evalValues[48 + pieceIndex * 8 + sq % 8]
                               << 3;
                    }
                }
            }
            
            // Here we interpolate the midgame/endgame scores from the single variable to a proper integer that can be used by search
            score = ((short)score * phase + score / 0x10000 * (24 - phase)) / 24;

            // Transposition table lookup
            // Look up best move known so far if it is available
            var (ttKey, ttMove, ttDepth, ttScore, ttFlag) = TT[key % 2097152];

            if (ttKey == key)
            {
                // If conditions match, we can trust the table entry and return immediately.
                // This is a token optimized way to express that: we can trust the score stored in TT and return immediately if:
                // 1. The depth remaining is higher or equal to our current
                //   a. Either the flag is exact, or:
                //   b. The stored score has an upper bound, but we scored below the stored score, or:
                //   c. The stored score has a lower bound, but we scored above the scored score
                if (!root && ttDepth >= depth && (ttFlag == 1 || ttFlag == 2 && ttScore >= beta || ttFlag == 0 && ttScore <= alpha))
                    return ttScore;
            }
            // Internal iterative reductions
            // If this is the first time we visit this node, it might not be worth searching it fully
            // because it might be a random non-promising node. If it gets visited a second time, it's worth fully looking into.
            else if (depth > 3)
                depth--;

            // We look at if it's worth capturing further based on the static evaluation
            if (inQsearch)
            {
                if (score >= beta)
                    return score;

                if (score > alpha)
                    alpha = score;

                bestScore = score;
            }

            // Move generation, best-known move then MVV-LVA ordering
            var moves = board.GetLegalMoves(inQsearch).OrderByDescending(move => move == ttMove ? 9_000_000_000_000_000_000
                                                                               : move.IsCapture ? 1_000_000_000_000_000_000 * (long)move.CapturePieceType - (long)move.MovePieceType
                                                                               : 0).ToArray();

            ttFlag = 0; // Upper

            // Loop over each legal move
            foreach (var move in moves)
            {
                board.MakeMove(move);
                nodes++; // #DEBUG

                score = -Search(false, depth - 1, -beta, -alpha);

                board.UndoMove(move);

                // If we are out of time, stop searching
                if (depth > 2 && timer.MillisecondsElapsedThisTurn > allocatedTime)
                    return bestScore;

                // If the move is better than our current best, update our best score
                if (score > bestScore)
                {
                    bestScore = score;

                    // If the move is better than our current alpha, update alpha and our best move
                    if (score > alpha)
                    {
                        ttMove = move;
                        if (root) rootBestMove = move;
                        alpha = score;
                        ttFlag = 1; // Exact

                        // If the move is better than our current beta, we can stop searching
                        if (score >= beta)
                        {
                            ttFlag++; // Lower
                            break;
                        }
                    }
                }
            }

            // Checkmate / stalemate detection
            // 1000000 = mate score
            if (moves.Length == 0)
                return inQsearch ? bestScore : board.IsInCheck() ? board.PlyCount - 1_000_000 : 0;

            // Store the current position in the transposition table
            TT[key % 2097152] = (key, ttMove, inQsearch ? 0 : depth, bestScore, ttFlag);

            return bestScore;
        }

        // Iterative deepening
        for (; timer.MillisecondsElapsedThisTurn <= allocatedTime / 5 /* Soft time limit */; ++depth)
        {
            int score = // #DEBUG
            Search(true, depth, -2_000_000, 2_000_000);

            // Hard time limit
            // If we are out of time, we stop searching and break.
            if (timer.MillisecondsElapsedThisTurn > allocatedTime)
                break;

            var elapsed = timer.MillisecondsElapsedThisTurn > 0 ? timer.MillisecondsElapsedThisTurn : 1; // #DEBUG
            Console.WriteLine($"info depth {depth} " + // #DEBUG
                              $"score cp {score} " + // #DEBUG
                              $"time {timer.MillisecondsElapsedThisTurn} " + // #DEBUG
                              $"nodes {nodes} " + // #DEBUG
                              $"nps {nodes * 1000 / elapsed} " + // #DEBUG
                              $"pv {rootBestMove.ToString().Substring(7, rootBestMove.ToString().Length - 8)}"); // #DEBUG
        }
        return rootBestMove;
    }
}
