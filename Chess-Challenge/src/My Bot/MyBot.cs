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
    static sbyte[] evalValues = (sbyte[])(Array)(new[] { 932095974022612493409452032m, 7461641848335305914170346501m, 12425519745374053625900047130m, 25472446271461558834940489004m, 3727175191630637160520876032m, 5905711669257279981134679308m, 11183933927904991431609357587m, 24232064676254075536917341219m, 18157672592554197249m }.SelectMany(x => decimal.GetBits(x).Take(3).SelectMany(BitConverter.GetBytes)).ToArray());

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
