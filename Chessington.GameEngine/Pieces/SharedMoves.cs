using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class SharedMove
    {
        public IEnumerable<Square> AvailableDiagonalMoves (Square currentSquare)
        {
            List<Square> potentialSquares = new List<Square>();
            for (int i = 0; i < 4; i++)
            {
                StepPosition stepPosition = new StepPosition(currentSquare.Col,currentSquare.Row);
                while (stepPosition.Col <= 7 && stepPosition.Col >= 0 && stepPosition.Row <= 7 && stepPosition.Row >= 0)
                {
                    potentialSquares.Add(Square.At(stepPosition.Col,stepPosition.Row));
                    stepPosition.StepColumn(i);
                    stepPosition.StepRow(i);
                }
            }
            potentialSquares.RemoveAll(square => square == currentSquare);
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