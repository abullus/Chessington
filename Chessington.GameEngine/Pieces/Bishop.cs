﻿using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            SharedMove sharedMove = new SharedMove();
            return sharedMove.AvailableDiagonalMoves(currentSquare, board, this);
        }
    }
}