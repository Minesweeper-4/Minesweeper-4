namespace Minesweeper.Logic.Draw
{
    using Minesweeper.Interfaces;
    using System;
    using System.Text;
    
    /// <summary>
    /// Sets the basic symbols of the matrix
    /// </summary>
    public class StandardPrinter : Printer
    {
        private const char UnrevealedCellCharacter = '?';
        private const char BombCharacter = '*';
        private const byte Offset = 3;

        /// <summary>
        /// Standard printer constructor
        /// </summary>
        public StandardPrinter()
        {
        }

        /// <summary>
        /// Print matrix
        /// </summary>
        /// <param name="matrix">Input matrix</param>
        /// <param name="player">Input player</param>
        public override void PrintMatrix(IMatrix matrix, IPlayer player)
        {
            Console.Clear();
            var printFrame = this.GetPrintFrame(matrix, player);
            Console.WriteLine(printFrame);
        }

        /// <summary>
        /// Prints the matrix with player info.
        /// </summary>
        /// <param name="matrix">Current matrix.</param>
        /// <param name="player">Current player.</param>
        /// <returns></returns>
        public override string GetPrintFrame(IMatrix matrix, IPlayer player)
        {
            var numberOfRows = matrix.Field.GetLength(0);
            var numberOfCols = matrix.Field.GetLength(1);
            var output = new StringBuilder();

            output.AppendLine("Score: " + player.Score);
            output.AppendLine();
            output.Append(this.AddRowIndexator(numberOfRows));
            output.Append(this.AddDashes(numberOfRows));

            for (int row = 0; row < numberOfRows; row++)
            {
                output.AppendFormat("{0, -2} | ", row);

                for (int col = 0; col < numberOfCols; col++)
                {
                    var currentCell = matrix.Field[row, col];

                    if (!currentCell.IsOpen)
                    {
                        output.AppendFormat("{0, -3}", UnrevealedCellCharacter);
                    }
                    else if (!currentCell.IsBomb)
                    {
                        if (currentCell.NumberOfMines != 0)
                        {
                            output.AppendFormat("{0, -3}", currentCell.NumberOfMines);
                        }
                        else
                        {
                            output.AppendFormat("{0, -3}", currentCell.NumberOfMines);
                        }
                    }
                    else
                    {
                        output.AppendFormat("{0, -3}", BombCharacter);
                    }
                }

                output.Append("|\n");
            }

            output.Append(this.AddDashes(numberOfRows));

            return output.ToString();
        }

        /// <summary>
        /// Method which prints string on the Console
        /// </summary>
        /// <param name="message">Input string</param>
        public override void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Formats and add row indexator
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <returns></returns>
        private StringBuilder AddRowIndexator(int rows)
        {
            var output = new StringBuilder();
            output.Append("     ");

            for (int i = 0; i < rows; i++)
            {
                output.AppendFormat("{0, -3}", i);
            }

            output.AppendLine();
            return output;
        }

        /// <summary>
        /// Formats and add dashes
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <returns></returns>
        private StringBuilder AddDashes(int rows)
        {
            var output = new StringBuilder();
            output.Append(" ");
            output.Append(" ");
            output.Append(" ");

            output.AppendLine(new string('-', (rows * Offset) + Offset));

            return output;
        }
    }
}
