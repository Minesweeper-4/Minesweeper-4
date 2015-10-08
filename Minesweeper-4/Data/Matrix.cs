namespace Minesweeper.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Inherits the Matrix interface, and implements the logic about the saving and loading the state, and setting the game difficulty
    /// </summary>
    public class Matrix : IMatrix
    {
        private ICell[,] field;

        /// <summary>
        /// An empty constructor for the Matrix class.
        /// </summary>
        public Matrix()
        {
        }

        /// <summary>
        /// Returns the number of rows in the Matrix field.
        /// </summary>
        public int Rows
        {
            get
            {
                return this.Field.GetLength(0);
            }
        }

        /// <summary>
        /// Returns the number of columns in the Matrix field.
        /// </summary>
        public int Cols
        {
            get
            {
                return this.Field.GetLength(1);
            }
        }

        /// <summary>
        /// Get and Set the Matrix field.
        /// </summary>
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

        /// <summary>
        /// Implements the Memento Design Pattern, to save the current state of the matrix
        /// </summary>
        /// <returns>Return the state of the matrix</returns>
        public MatrixMemento SaveMemento()
        {
            return new MatrixMemento(this.Field);
        }

        /// <summary>
        /// Loads the previously saved state
        /// </summary>
        /// <param name="memento">Needs as parameter the saved state</param>
        public void RestoreMemento(MatrixMemento memento)
        {
            this.Field = memento.Field;
        }

        /// <summary>
        /// Set bombs in the Matrix Field.
        /// </summary>
        /// <param name="numberOfBombs">Number of bombs to be set.</param>
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
                int row = number / boardColumns;
                int column = number % boardColumns;
                if (column == 0 && number != 0)
                {
                    row--;
                    column = boardColumns;
                }
                else
                {
                    column++;
                }

                this.Field[row, column - 1].IsBomb = true;
            }
        }

        /// <summary>
        /// Set the number of surrounded mines for each cell.
        /// </summary>
        public void SetNumberOfMines()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    this.Field[row, col].NumberOfMines = this.GetNumberOfMines(row, col);
                }
            }
        }

        /// <summary>
        /// Calculate how many bombs there are around current Cell.
        /// </summary>
        /// <param name="cellRow">Integeer number of the current row of the Cell.</param>
        /// <param name="cellCol">Integeer number of the current column of the Cell.</param>
        /// <returns>Return integeer number of bombs around current Cell.</returns>
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
                    if (this.Field[row, col].IsBomb)
                    {
                        numberOfBombs++;
                    }
                }
            }

            return numberOfBombs;
        }
    }
}
