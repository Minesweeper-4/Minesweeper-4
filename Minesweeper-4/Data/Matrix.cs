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

        public MatrixMemento SaveMemento()
        {
            return new MatrixMemento(this.Field);
        }

        public void RestoreMemento(MatrixMemento memento)
        {
            this.Field = memento.Field;
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

        public void SetNumberOfMines()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    this.Field[row, col].NumberOfMines = GetNumberOfMines(row, col);
                }
            }
        }

        private int GetNumberOfMines(int cellRow, int cellCol)
        {
            var minRow = Math.Max(0, cellRow - 1);
            var maxRow = Math.Min(cellRow + 1, this.Cols - 1);
            var minCol = Math.Max(0, cellCol - 1);
            var maxCol = Math.Min(cellCol + 1, this.Cols - 1);
            int numberOfBombs = 0;

            for (int row = minRow; row <= maxRow; row++)
            {
                for (int col = minCol; col <= maxCol; col++)
                {
                    if (this.Field[row, col].IsBoomb)
                    {
                        numberOfBombs++;
                    }
                }
            }

            return numberOfBombs;
        }
    }
}
