using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class SharedMove
    {
        public IEnumerable<Square> AvailableDiagonalMoves (Square currentSquare, Board board, Piece piece)
        {
            List<Square> potentialSquares = new List<Square>();
            for (int i = 0; i < 4; i++)
            {
                bool inRange = true;
                StepPosition stepPosition = new StepPosition(currentSquare.Col,currentSquare.Row);
                do
                {
                    potentialSquares.Add(Square.At(stepPosition.Col,stepPosition.Row));
                    stepPosition.StepColumn(i);
                    stepPosition.StepRow(i);
                    if (stepPosition.Col > 7 || stepPosition.Col < 0 || stepPosition.Row > 7 || stepPosition.Row < 0)
                    {
                        inRange = false;
                        break;
                    }
                } while (board.GetPiece(Square.At(stepPosition.Col, stepPosition.Row)) == null);

                if (inRange == true)
                {
                    if (board.GetPiece(Square.At(stepPosition.Col, stepPosition.Row)).Player != piece.Player)
                    {
                        potentialSquares.Add(Square.At(stepPosition.Col,stepPosition.Row));
                    }
                }
                
                
            }
            potentialSquares.RemoveAll(square => square == currentSquare);
            return potentialSquares;
        }
        public IEnumerable<Square> AvailableLateralMoves(Square currentSquare, Board board, Piece piece)
        {
            List<Square> potentialSquares = new List<Square>();
            for (int i = 0; i < 4; i++)
            {
                bool inRange = true;
                StepPosition stepPosition = new StepPosition(currentSquare.Col, currentSquare.Row);
                do
                {
                    potentialSquares.Add(Square.At(stepPosition.Col, stepPosition.Row));
                    stepPosition.StepLateral(i);
                    if (stepPosition.Col > 7 || stepPosition.Col < 0 || stepPosition.Row > 7 || stepPosition.Row < 0)
                    {
                        inRange = false;
                        break;
                    }
                } while (board.GetPiece(Square.At(stepPosition.Col, stepPosition.Row)) == null);

                if (inRange == true)
                {
                    if (board.GetPiece(Square.At(stepPosition.Col, stepPosition.Row)).Player != piece.Player)
                    {
                        potentialSquares.Add(Square.At(stepPosition.Col, stepPosition.Row));
                    }
                }
            }

            potentialSquares.RemoveAll(square => square == currentSquare);
            return potentialSquares;
        }
    }
}