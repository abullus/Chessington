using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            List<Square> potentialSquares = new List<Square>();
            for (int i = -2; i <= 2; i+=4)
            {
                for (int j = -1; j <= 1; j+=2)
                {
                    potentialSquares.Add(Square.At(currentSquare.Row + i, currentSquare.Col + j));
                    potentialSquares.Add(Square.At(currentSquare.Row + j, currentSquare.Col + i));
                }
            }
            return potentialSquares.Where(square => square.Col <= 7 && square.Col >=0 && square.Row <= 7 && square.Col >= 0);
        }
    }
}