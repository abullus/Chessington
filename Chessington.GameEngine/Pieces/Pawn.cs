using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player)
        {
        }


        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            List<Square> potentialSquares = new List<Square>();

            int playerDirection;
            if (this.Player == Player.White)
            {
                playerDirection = -1;
            }
            else
            {
                playerDirection = 1;
            }


            if (currentSquare.Row + playerDirection <= 7 && currentSquare.Row + playerDirection >= 0 &&
                currentSquare.Col <= 7 && currentSquare.Col >= 0)
            {
                if (board.GetPiece(Square.At(currentSquare.Row + playerDirection, currentSquare.Col)) == null)
                {
                    potentialSquares.Add(Square.At(currentSquare.Row + playerDirection, currentSquare.Col));
                    if (this.HasMoved == false)
                    {
                        if (currentSquare.Row + 2 * playerDirection <= 7 &&
                            currentSquare.Row + 2 * playerDirection >= 0 && currentSquare.Col <= 7 &&
                            currentSquare.Col >= 0)
                        {
                            if (board.GetPiece(Square.At(currentSquare.Row + 2 * playerDirection, currentSquare.Col)) ==
                                null)
                            {
                                potentialSquares.Add(Square.At(currentSquare.Row + playerDirection * 2,
                                    currentSquare.Col));
                            }
                        }
                    }
                }
            }

            for (int i = -1; i <= 1; i += 2)
            {
                if (currentSquare.Row + playerDirection <= 7 && currentSquare.Row + playerDirection >= 0 &&
                    currentSquare.Col + i <= 7 && currentSquare.Col + i >= 0)
                {
                    var piece = board.GetPiece(Square.At(currentSquare.Row + playerDirection,
                        currentSquare.Col + i));
                    if (piece != null && piece.Player != this.Player)
                    {
                        potentialSquares.Add(Square.At(currentSquare.Row + playerDirection,
                            currentSquare.Col + i));
                    }
                }
            }


            return potentialSquares;
        }
    }
}