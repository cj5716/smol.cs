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
    static sbyte[] evalValues = (sbyte[])(Array)(new[] { 1242794632030055060954152960m, 9638959917358734347501179143m, 13667096062770198235270358049m, 32928005563687163324309647920m, 4660484869179300080661561344m, 8392514766621419204747858192m, 18330003468483261489452227867m, 33242326295523352037375490618m, 18085334627329638657m }.SelectMany(x => decimal.GetBits(x).Take(3).SelectMany(BitConverter.GetBytes)).ToArray());

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

                    // 6x quantization, rank and file PSTs  (~20 Elo off full PSTs)
                    // Material is encoded within the PSTs
                    score += (evalValues[pieceIndex * 8 + sq / 8]
                           +  evalValues[48 + pieceIndex * 8 + sq % 8]) * 6;

                }
            }

            score = depth <= 0 ? alpha = Math.Max(score, alpha)
                  : depth <= 5 ? score - 100 * depth
                               : alpha;

            // Loop over each legal move
            // TT move then MVV-LVA
            foreach (var move in board.GetLegalMoves(depth <= 0).OrderByDescending(move => (move == TT[key], move.CapturePieceType, 0 - move.MovePieceType)))
            {
                if (score >= beta)
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
