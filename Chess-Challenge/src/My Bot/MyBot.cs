using System;
using System.Linq;
using ChessChallenge.API;

public class MyBot : IChessBot
{
    // Root best move
    Move rootBestMove;

    // TT moves
    Move[] TT = new Move[8388608];

    // Extract function to extract values from ulong
    /*
    sbyte Extract(ulong term, int index) => (sbyte)(term >> index * 8);
    */
    // Currently, this is inlined into eval to save tokens

    public Move Think(Board board, Timer timer)
    {
        int globalDepth = 0;

        long nodes = 0; // #DEBUG

        int Search(int depth, int alpha, int beta)
        {
            // Assign zobrist key
            // Score is init to tempo value of 15
            // Eval terms packed into ulongs (8 bytes per value)
            var(key, score, evalValues) = (board.ZobristKey % 8388608,
                                           15,
                                           new[] {284790775349248ul, 8462971131134976ul, 2244245241712484124ul, 2604249533607322657ul, 3617290108189354026ul, 7666648729631482466ul, 17592202559488ul, 1013891626781577231ul, 1954034614987070487ul, 2025806318754667803ul, 3907499648473512247ul, 7739832227938657635ul, 18085334627329638657ul});

            foreach (bool isWhite in new[] {!board.IsWhiteToMove, board.IsWhiteToMove})
            {
                score = -score;
                ulong bitboard = isWhite ? board.WhitePiecesBitboard : board.BlackPiecesBitboard,
                      sideBB = bitboard;

                while (bitboard != 0)
                {
                    int sq = BitboardHelper.ClearAndGetIndexOfLSB(ref bitboard),
                        pieceIndex = (int)board.GetPiece(new (sq)).PieceType;

                    // Mobility, we use the raw value instead of evalValues[0] because it is smaller
                    // (sbyte)(284790775349248 >> pieceIndex * 8) is equivalent to Extract(284790775349248, pieceIndex)
                    score += (sbyte)(284790775349248 >> pieceIndex * 8) * BitboardHelper.GetNumberOfSetBits(BitboardHelper.GetPieceAttacks((PieceType)pieceIndex, new (sq), board, isWhite) & ~sideBB);

                    // Flip square if black
                    if (!isWhite)
                        sq ^= 56;

                    // 6x quantization, rank and file PSTs  (~20 Elo off full PSTs)
                    // Material is encoded within the PSTs
                    // Equivalent to:
                    /*
                    score += (Extract(evalValues[pieceIndex], sq / 8)
                           +  Extract(evalValues[pieceIndex + 6], sq % 8)) * 6;
                    */
                    score += ((sbyte)(evalValues[pieceIndex] >> (sq & 0b111000))
                           +  (sbyte)(evalValues[pieceIndex + 6] >> sq % 8 * 8)) * 6;

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

                score = board.IsInCheckmate() ? 1_000_000 - board.PlyCount
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
