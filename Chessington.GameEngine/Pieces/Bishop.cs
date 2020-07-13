using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            List<Square> potentialSquares = new List<Square>();
            int col = currentSquare.Col;
            int row = currentSquare.Row;
            
            while (col < 7 && row < 7)
            {
                col++;
                row++;
                potentialSquares.Add(Square.At(col, row));
            }
            
            col = currentSquare.Col;
            row = currentSquare.Row;
            while (col < 7 && row > 0)
            {
                col++;
                row--;
                potentialSquares.Add(Square.At(col, row));
            }
            
            col = currentSquare.Col;
            row = currentSquare.Row;
            while (col > 0 && row < 7)
            {
                col--;
                row++;
                potentialSquares.Add(Square.At(col, row));
            }
            
            col = currentSquare.Col;
            row = currentSquare.Row;
            while (col > 0 && row > 0)
            {
                col--;
                row--;
                potentialSquares.Add(Square.At(col, row));
            }
            
            potentialSquares.Remove(currentSquare);
            return potentialSquares.Where(square => board.GetPiece(square)  == null );
        }
    }
}