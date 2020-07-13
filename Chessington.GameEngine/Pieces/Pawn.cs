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
            List<Square> availableMoves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            List<Square> potentialSquare = new List<Square>();
            if (this.Player == Player.White)
            {
                potentialSquare.Add(Square.At(currentSquare.Row-1,currentSquare.Col));
                if (this.HasMoved == false)
                {
                    potentialSquare.Add(Square.At(currentSquare.Row-2,currentSquare.Col));
                }
            }
            if (this.Player == Player.Black)
            {
                potentialSquare.Add(Square.At(currentSquare.Row+1,currentSquare.Col));
                if (this.HasMoved == false)
                {
                    potentialSquare.Add(Square.At(currentSquare.Row+2,currentSquare.Col));
                }
            }
            
            foreach (var square in potentialSquare)
            {
                if (board.GetPiece(square) == null)
                {
                    availableMoves.Add(square);
                }
            }
            
            
            return availableMoves;
        }
    }
}