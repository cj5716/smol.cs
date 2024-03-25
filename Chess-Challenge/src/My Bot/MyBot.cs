// Project: smol.cs
// License: MIT
// Authors: Gediminas Masaitis, Goh CJ (cj5716)

using System;
using System.Collections.Generic;
using System.Linq;
using ChessChallenge.API;

public class MyBot : IChessBot
{
    // Transposition table
    // Key, move, depth, score, flag
    (ulong, Move, int, int, byte)[] TT = new (ulong, Move, int, int, byte)[2097152];

    // Eval terms packed into C# decimals, as it has 12 usable bytes per token and is thus the most efficient.
    // It is ordered as MG term 1, EG term 1, MG term 2, EG term 2 etc.
    static sbyte[] extracted = new [] { 4835740172228143389605888m, 2477126802417782031162277888m, 8987268064278214852567370499m, 10217997163295925037733585164m, 11160973432655769285841133323m, 15490188721000912996060636172m, 29756944731101898114373858066m, 35638477370265809412994327845m, 19342813114113316978950144m, 4029415944847360518751518720m, 9914528280548214173287845126m, 9295591374614011062820480010m, 9297990354729639866572414218m, 19514783056024713615916080651m, 31298343949203241391214116622m, 33160132234332197119198324513m, 8043016548800136891691039241m, 71819879314466714244163308032m }.SelectMany(x => decimal.GetBits(x).Take(3).SelectMany(y => (sbyte[])(Array)BitConverter.GetBytes(y))).ToArray();

    // We pack the terms into ints, where each int is EG << 16 | MG
    // This allows us to make use of SWAR (SIMD Within A Register) which is both a speed optimisation and a token one
    // See https://minuskelvin.net/chesswiki/content/packed-eval.html
    int[] evalValues = Enumerable.Range(0, 108).Select(i => extracted[i * 2] | extracted[i * 2 + 1] << 16).ToArray();

    public Move Think(Board board, Timer timer)
    {
        Move rootBestMove = default;

        var (allocatedTime, i, depth) = (timer.MillisecondsRemaining / 8, 0, 1);

        long nodes = 0; // #DEBUG

        int Search(bool root, int depth, int alpha, int beta)
        {
            // Assign zobrist key and whether we are in qsearch, as well as bestScore to -inf
            // Score is init to tempo value of S(15, 1) (extra 1 to compensate for the division vs add + shift later on), and phase is init to 0
            var (key, inQsearch, bestScore, score, phase) = (board.ZobristKey, depth <= 0, -2_000_000, 65551, 0);

            foreach (bool isWhite in new[] {!board.IsWhiteToMove, board.IsWhiteToMove})
            {
                score = -score;
                ulong bitboard = isWhite ? board.WhitePiecesBitboard : board.BlackPiecesBitboard,
                      sideBB = bitboard;

                while (bitboard != 0)
                {
                    int sq = BitboardHelper.ClearAndGetIndexOfLSB(ref bitboard),
                        pieceIndex = (int)board.GetPiece(new(sq)).PieceType;

                    // Mobility for bishop, rook, queen, king
                    if (pieceIndex > 2)
                        score += evalValues[101 + pieceIndex] * BitboardHelper.GetNumberOfSetBits(BitboardHelper.GetPieceAttacks((PieceType)pieceIndex, new (sq), board, isWhite) & ~sideBB);

                    // Flip square if black
                    if (!isWhite)
                        sq ^= 56;

                    // Increment phase for tapered eval (Pawn = 0, Minor = 1, Rook = 2, Queen = 4, King = 0)
                    phase += evalValues[pieceIndex];

                    // 8x quantization, rank and file PSTs  (~20 Elo off full PSTs)
                    // Material is encoded within the PSTs
                    score += evalValues[pieceIndex * 8 + sq / 8]
                           + evalValues[48 + pieceIndex * 8 + sq % 8]
                           << 3;

                }
            }
            
            // Here we interpolate the midgame/endgame scores from the single variable to a proper integer that can be used by search
            score = ((short)score * phase + score / 0x10000 * (24 - phase)) / 24;

            // Transposition table lookup
            // Look up best move known so far if it is available
            var (ttKey, ttMove, ttDepth, ttScore, ttFlag) = TT[key % 2097152];

            // TT cutoff
            if (!root && ttKey == key && ttDepth >= depth && (ttFlag == 1 || ttFlag == 2 && ttScore >= beta || ttFlag == 0 && ttScore <= alpha))
                return ttScore;

            // We look at if it's worth capturing further based on the static evaluation
            if (inQsearch)
            {
                // Stand pat
                if (score >= beta)
                    return score;

                if (score > alpha)
                    alpha = score;

                bestScore = score;
            }

            ttFlag = 0; // Upper

            // Loop over each legal move
            // TT move then MVV-LVA
            foreach (var move in board.GetLegalMoves(inQsearch).OrderByDescending(move => (move == ttMove, move.CapturePieceType, 0 - move.MovePieceType)))
            {
                if (alpha >= beta)
                {
                    ttFlag = 2; // Lower
                    break;
                }

                board.MakeMove(move);
                nodes++; // #DEBUG

                score = board.IsInCheckmate() ? -1_000_000 + board.PlyCount
                      :      board.IsDraw()   ? 0
                                              : -Search(false, depth - 1, -beta, -alpha);

                board.UndoMove(move);

                Convert.ToUInt32(depth > 2 && timer.MillisecondsElapsedThisTurn > allocatedTime);

                if (score > bestScore)
                    bestScore = score;

                if (score > alpha)
                {
                    ttMove = move;
                    if (root) rootBestMove = move;
                    alpha = score;
                    ttFlag = 1; // Exact
                }
            }

            // Store the current position in the transposition table
            TT[key % 2097152] = (key, ttMove, inQsearch ? 0 : depth, bestScore, ttFlag);

            return bestScore;
        }

        try {
            // Iterative deepening
            for (; timer.MillisecondsElapsedThisTurn <= allocatedTime / 5 /* Soft time limit */; ++depth)
            { // #DEBUG
                int score = // #DEBUG
                Search(true, depth, -2_000_000, 2_000_000);

                var elapsed = timer.MillisecondsElapsedThisTurn > 0 ? timer.MillisecondsElapsedThisTurn : 1; // #DEBUG
                Console.WriteLine($"info depth {depth} " + // #DEBUG
                                  $"score cp {score} " + // #DEBUG
                                  $"time {timer.MillisecondsElapsedThisTurn} " + // #DEBUG
                                  $"nodes {nodes} " + // #DEBUG
                                  $"nps {nodes * 1000 / elapsed} " + // #DEBUG
                                  $"pv {rootBestMove.ToString().Substring(7, rootBestMove.ToString().Length - 8)}"); // #DEBUG
            } // #DEBUG
        }
        catch {}
        return rootBestMove;
    }
}
