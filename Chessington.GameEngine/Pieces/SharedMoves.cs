using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class SharedMove
    {
        public IEnumerable<Square> AvailableDiagonalMoves (Square currentSquare)
        {
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
            return potentialSquares;
        }
        public IEnumerable<Square> AvailableLateralMoves(Square currentSquare)
        {
            List<Square> potentialSquares = new List<Square>();
            for (var i = 0; i < 8; i++)
                potentialSquares.Add(Square.At(currentSquare.Row, i));

            for (var i = 0; i < 8; i++)
                potentialSquares.Add(Square.At(i, currentSquare.Col));

            potentialSquares.RemoveAll(square => square == currentSquare);
            return potentialSquares;
        }
    }
}