namespace Minesweeper.Logic
{
    using System;
    using System.Collections.Generic;
    using Minesweeper.Data;
    using Minesweeper.Interfaces;

    public class MatrixLogic
    {
        public MatrixLogic()
        {
        }

        public ICell[,] InitBoard(ICell[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var currentCell = new Cell('?');
                    matrix[i, j] = currentCell;
                }
            }

            matrix = AddBombs(matrix);

            return matrix;
        }

        public void MakeAMove(ICell[,] board, int rowIndex, int colIndex)
        {
            //char surroundingBombsCount = CalculateSurrounding(board, rowIndex, colIndex);
            board[rowIndex, colIndex].IsOpen = true;
        }

        private ICell[,] AddBombs(ICell[,] matrix)
        {
            int boardColumns = matrix.GetLength(1);
            List<int> randomNumbers = new List<int>();

            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
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

                matrix[row, column - 1].IsBoomb = true;
            }

            return matrix;
        }

        private char CalculateSurrounding(ICell[,] board, int rowIndex, int columnIndex)
        {
            int counted = 0;
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);

            if (rowIndex - 1 >= 0)
            {
                if (board[rowIndex - 1, columnIndex].IsBoomb)
                { counted++; }
            }
            if (rowIndex + 1 < boardRows)
            {
                if (board[rowIndex + 1, columnIndex].IsBoomb)
                {
                    counted++;
                }
            }

            if (columnIndex - 1 >= 0)
            {
                if (board[rowIndex, columnIndex - 1].IsBoomb)
                { counted++; }
            }

            if (columnIndex + 1 < boardColumns)
            {
                if (board[rowIndex, columnIndex + 1].IsBoomb)
                {
                    counted++;
                }
            }

            if ((rowIndex - 1 >= 0) && (columnIndex - 1 >= 0))
            {
                if (board[rowIndex - 1, columnIndex - 1].IsBoomb)
                {
                    counted++;
                }
            }

            if ((rowIndex - 1 >= 0) && (columnIndex + 1 < boardColumns))
            {
                if (board[rowIndex - 1, columnIndex + 1].IsBoomb)
                {
                    counted++;
                }
            }

            if ((rowIndex + 1 < boardRows) && (columnIndex - 1 >= 0))
            {
                if (board[rowIndex + 1, columnIndex - 1].IsBoomb)
                {
                    counted++;
                }
            }

            if ((rowIndex + 1 < boardRows) && (columnIndex + 1 < boardColumns))
            {
                if (board[rowIndex + 1, columnIndex + 1].IsBoomb)
                {
                    counted++;
                }
            }

            return char.Parse(counted.ToString());
        }
    }
}
