using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            List<Square> potentialSquares = new List<Square>();

            int playerDirection;
            if (this.Player == Player.White)
            {
                playerDirection = -1;
            }else {
                playerDirection = 1;
            }

            if (currentSquare.Row != 3.5 + 3.5 * playerDirection)
            {
                if (board.GetPiece(Square.At(currentSquare.Row + playerDirection, currentSquare.Col)) == null)
                {
                    potentialSquares.Add(Square.At(currentSquare.Row+ playerDirection,currentSquare.Col));
                    if (currentSquare.Row != 3.5 + 2.5 * playerDirection)
                    {
                        if (this.HasMoved == false && board.GetPiece(Square.At(currentSquare.Row + playerDirection*2 ,currentSquare.Col))  == null)
                        {
                            potentialSquares.Add(Square.At(currentSquare.Row+ playerDirection*2,currentSquare.Col));
                        }
                    }
                }
            }
            
            
            return potentialSquares;
        }
    }
}