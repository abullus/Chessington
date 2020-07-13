using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            List<Square> potentialSquares = new List<Square>();
            for (var i = 0; i < 8; i++)
                potentialSquares.Add(Square.At(currentSquare.Row, i));

            for (var i = 0; i < 8; i++)
                potentialSquares.Add(Square.At(i, currentSquare.Col));

            potentialSquares.Remove(currentSquare);
            return potentialSquares;
            //return potentialSquares.Where(square => board.GetPiece(square)  == null );
        }
    }
}