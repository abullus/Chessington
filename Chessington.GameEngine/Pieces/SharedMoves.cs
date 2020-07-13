using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class SharedMove
    {
        public IEnumerable<Square> AvailableDiagonalMoves (Square currentSquare, Board board)
        {
            List<Square> potentialSquares = new List<Square>();
            for (int i = 0; i < 4; i++)
            {
                StepPosition stepPosition = new StepPosition(currentSquare.Col,currentSquare.Row);
                do
                {
                    potentialSquares.Add(Square.At(stepPosition.Col,stepPosition.Row));
                    stepPosition.StepColumn(i);
                    stepPosition.StepRow(i);
                    if (stepPosition.Col > 7 || stepPosition.Col < 0 || stepPosition.Row > 7 || stepPosition.Row < 0)
                    {
                        break;
                    }
                } while (board.GetPiece(Square.At(stepPosition.Col, stepPosition.Row))==null);
                
            }
            potentialSquares.RemoveAll(square => square == currentSquare);
            return potentialSquares;
        }
        public IEnumerable<Square> AvailableLateralMoves(Square currentSquare, Board board)
        {
            List<Square> potentialSquares = new List<Square>();
            for (int i = 0; i < 4; i++)
            {
                StepPosition stepPosition = new StepPosition(currentSquare.Col,currentSquare.Row);
                do
                {
                    potentialSquares.Add(Square.At(stepPosition.Col,stepPosition.Row));
                    stepPosition.StepLateral(i);
                    if (stepPosition.Col > 7 || stepPosition.Col < 0 || stepPosition.Row > 7 || stepPosition.Row < 0)
                    {
                        break;
                    }
                } while (board.GetPiece(Square.At(stepPosition.Col, stepPosition.Row))==null);
            }

            potentialSquares.RemoveAll(square => square == currentSquare);
            return potentialSquares;
        }
    }
}