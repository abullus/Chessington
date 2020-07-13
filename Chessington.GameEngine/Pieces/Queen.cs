using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            SharedMove sharedMove = new SharedMove();
            List<Square> potentialSquares = new List<Square>();
            
            potentialSquares.AddRange(sharedMove.AvailableDiagonalMoves(currentSquare));
            potentialSquares.AddRange(sharedMove.AvailableLateralMoves(currentSquare));

            return potentialSquares;
        }
    }
}