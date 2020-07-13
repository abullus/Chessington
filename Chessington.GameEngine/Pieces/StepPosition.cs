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

        public void StepLateral(int counter)
        {
            switch (counter)
            {
                case 0:
                    Row--;
                    break;
                case 1:
                    Row++;
                    break;
                case 2:
                    Col--;
                    break;
                case 3:
                    Col++;
                    break;


            }
        }
    }
}