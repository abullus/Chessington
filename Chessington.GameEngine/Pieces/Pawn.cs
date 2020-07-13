using System.Collections.Generic;
using System.Linq;

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
            Square potentialSquare = new Square();
            if (this.Player == Player.White)
            {
                potentialSquare  =  Square.At(currentSquare.Row-1,currentSquare.Col);
            }
            if (this.Player == Player.Black)
            {
                potentialSquare = Square.At(currentSquare.Row+1,currentSquare.Col);
            }

            if (board.GetPiece(potentialSquare) == null)
            {
                availableMoves.Add(potentialSquare);
            }
            
            return availableMoves;
        }
    }
}