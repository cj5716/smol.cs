using System;
using System.Linq;
using ChessChallenge.API;

public class MyBot : IChessBot
{
    // Root best move
    Move rootBestMove;

    // TT moves
    Move[] TT = new Move[8388608];

    // Eval terms packed into C# decimals, as it has 12 usable bytes per token and is thus the most efficient.
    static sbyte[] evalValues = new[] { 4835740172228143389605888m, 2477126802417782031162277888m, 8987268064278214852567370499m, 10217997163295925037733585164m, 11160973432655769285841133323m, 15490188721000912996060636172m, 29756944731101898114373858066m, 35638477370265809412994327845m, 19342813114113316978950144m, 4029415944847360518751518720m, 9914528280548214173287845126m, 9295591374614011062820480010m, 9297990354729639866572414218m, 19514783056024713615916080651m, 31298343949203241391214116622m, 33160132234332197119198324513m, 8043016548800136891691039241m, 71819879314466714244163308032m }.SelectMany(x => decimal.GetBits(x).Take(3).SelectMany(y => (sbyte[])(Array)BitConverter.GetBytes(y))).ToArray();

    public Move Think(Board board, Timer timer)
    {
        int globalDepth = 0;

        long nodes = 0; // #DEBUG

        int Search(int depth, int alpha, int beta)
        {
            // Assign zobrist key
            // Score is init to tempo value of 15
            ulong key = board.ZobristKey % 8388608;
            int score = 15;

            foreach (bool isWhite in new[] {!board.IsWhiteToMove, board.IsWhiteToMove})
            {
                score = -score;
                ulong bitboard = isWhite ? board.WhitePiecesBitboard : board.BlackPiecesBitboard,
                      sideBB = bitboard;

                while (bitboard != 0)
                {
                    int sq = BitboardHelper.ClearAndGetIndexOfLSB(ref bitboard),
                        pieceIndex = (int)board.GetPiece(new (sq)).PieceType;

                    // Mobility
                    score += evalValues[pieceIndex] * BitboardHelper.GetNumberOfSetBits(BitboardHelper.GetPieceAttacks((PieceType)pieceIndex, new (sq), board, isWhite) & ~sideBB);

                    // Flip square if black
                    if (!isWhite)
                        sq ^= 56;

                    // 8x quantization, rank and file PSTs  (~20 Elo off full PSTs)
                    // Material is encoded within the PSTs
                    score += evalValues[pieceIndex * 8 + sq / 8]
                           + evalValues[48 + pieceIndex * 8 + sq % 8]
                           << 3;

                }
            }

            if (depth <= 0 && score > alpha)
                alpha = score;

            // Loop over each legal move
            // TT move then MVV-LVA
            foreach (var move in board.GetLegalMoves(depth <= 0).OrderByDescending(move => (move == TT[key], move.CapturePieceType, 0 - move.MovePieceType)))
            {
                if (alpha >= beta)
                    return beta;

                board.MakeMove(move);
                nodes++; // #DEBUG

                score = board.IsInCheckmate() ? -1_000_000 + board.PlyCount
                      :        board.IsDraw() ? 0
                                              : -Search(depth - 1, -beta, -alpha);

                board.UndoMove(move);

                if (score > alpha)
                {
                    TT[key] = move;
                    if (depth == globalDepth) rootBestMove = move;
                    alpha = score;
                }

                Convert.ToUInt32(timer.MillisecondsRemaining - timer.MillisecondsElapsedThisTurn * 8);
            }

            return alpha;
        }

        try {
            // Iterative deepening, soft time limit
            while (timer.MillisecondsElapsedThisTurn <= timer.MillisecondsRemaining / 40)
            { // #DEBUG
                int score = // #DEBUG
                Search(++globalDepth, -2_000_000, 2_000_000);

                var elapsed = timer.MillisecondsElapsedThisTurn > 0 ? timer.MillisecondsElapsedThisTurn : 1; // #DEBUG
                Console.WriteLine($"info depth {globalDepth} " + // #DEBUG
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
