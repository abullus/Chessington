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
            
            if (this.Player == Player.White)
            {
                potentialSquares.Add(Square.At(currentSquare.Row-1,currentSquare.Col));
                if (this.HasMoved == false)
                {
                    potentialSquares.Add(Square.At(currentSquare.Row-2,currentSquare.Col));
                }
            }
            if (this.Player == Player.Black)
            {
                potentialSquares.Add(Square.At(currentSquare.Row+1,currentSquare.Col));
                if (this.HasMoved == false)
                {
                    potentialSquares.Add(Square.At(currentSquare.Row+2,currentSquare.Col));
                }
            }

            return potentialSquares.Where(square => board.GetPiece(square)  == null );
        }
    }
}