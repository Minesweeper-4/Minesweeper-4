using Minesweeper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic.Draw
{
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
            var printFrame = GetPrintFrame(matrix, player);
            Console.WriteLine(printFrame);
        }

        public override string GetPrintFrame(IMatrix matrix, IPlayer player)
        {
            var numberOfRows = matrix.Field.GetLength(0);
            var numberOfCols = matrix.Field.GetLength(1);
            var output = new StringBuilder();

            output.AppendLine("Score: " + player.Score);
            output.AppendLine();
            output.Append(AddRowIndexator(numberOfRows));
            output.Append(AddDashes(numberOfRows));

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
                            output.AppendFormat("{0, -3}", currentCell.NumberOfMines); //TODO Represent zero cells as empty space character
                        }
                    }
                    else
                    {
                        output.AppendFormat("{0, -3}", BombCharacter);
                    }
                }

                output.Append("|\n");
            }
            output.Append(AddDashes(numberOfRows));

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
                output.AppendFormat("{0, -3}", i); //TODO can move 3 to constant
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

            output.AppendLine(new string('-', (rows * 3) + 3)); //TODO can move 3 to constant

            return output;
        }
    }
}
