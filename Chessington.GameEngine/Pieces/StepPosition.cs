using System.Net.Configuration;

namespace Chessington.GameEngine.Pieces
{
    public class StepPosition
    {
        public int Row;
        public int Col;

        public StepPosition(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public void StepColumn(int counter)
        {
            if (counter < 2)
            {
                Col++;
            }
            else
            {
                Col--;
            }
        }

        public void StepRow(int counter)
        {
            if (counter == 0 || counter == 2)
            {
                Row++;
            }
            else
            {
                Row--;
            }
        }
    }
}