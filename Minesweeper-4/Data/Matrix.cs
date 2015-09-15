namespace Minesweeper.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Minesweeper.Interfaces;

    public class Matrix : IMatrix
    {
        private int rows;
        private int cols;
        private ICell[,] field;

        public Matrix()
        {
        }

        public int Rows
        {
            get
            {
                return this.Field.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.Field.GetLength(1);
            }
        }

        public ICell[,] Field
        {
            get
            {
                return this.field;
            }

            set
            {
                this.field = value;
            }
        }

        public void SetBombs(int numberOfBombs)
        {
            int boardColumns = this.Field.GetLength(1);
            List<int> randomNumbers = new List<int>();

            while (randomNumbers.Count < numberOfBombs)
            {
                Random random = new Random();
                int randomNumber = random.Next(this.Cols * this.Rows);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (int number in randomNumbers)
            {
                int row = (number / boardColumns);
                int column = (number % boardColumns);
                if (column == 0 && number != 0)
                {
                    row--;
                    column = boardColumns;
                }

                else
                {
                    column++;
                }

                this.Field[row, column - 1].IsBoomb = true;
            }

        }
    }
}
