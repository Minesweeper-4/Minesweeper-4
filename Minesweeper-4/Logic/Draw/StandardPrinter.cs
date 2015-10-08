namespace Minesweeper.Logic.Draw
{
    using System;
    using System.Text;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Sets the basic symbols of the matrix
    /// </summary>
    public class StandardPrinter : Printer
    {
        private const char UnrevealedCellCharacter = '?';
        private const char BombCharacter = '*';

        public StandardPrinter()
        {
        }

        public override void PrintMatrix(IMatrix matrix, IPlayer player)
        {
            Console.Clear();
            var printFrame = this.GetPrintFrame(matrix, player);
            Console.WriteLine(printFrame);
        }

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
                            output.AppendFormat("{0, -3}", currentCell.NumberOfMines); ///TODO Represent zero cells as empty space character
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

        public override void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        private StringBuilder AddRowIndexator(int rows)
        {
            var output = new StringBuilder();
            output.Append("     ");

            for (int i = 0; i < rows; i++)
            {
                output.AppendFormat("{0, -3}", i); ///TODO can move 3 to constant
            }

            output.AppendLine();
            return output;
        }

        private StringBuilder AddDashes(int rows)
        {
            var output = new StringBuilder();
            output.Append(" ");
            output.Append(" ");
            output.Append(" ");

            output.AppendLine(new string('-', (rows * 3) + 3)); ///TODO can move 3 to constant

            return output;
        }
    }
}
