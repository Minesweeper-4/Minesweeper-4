using Minesweeper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic.Draw
{
    class StandardPrinter : Printer
    {
        private const char UnrevealedCellCharacter = '?';
        private const char BombCharacter = '*';

        public StandardPrinter()
        {

        }

        public override void PrintMatrix(IMatrix matrix, IPlayer player)
        {
            Console.Clear();

            var numberOfRows = matrix.Field.GetLength(0);
            var numberOfCols = matrix.Field.GetLength(1);
            var output = new StringBuilder();

            output.AppendLine("Score: " + player.Score);
            output.AppendLine();
            output.Append(AddRowIndexator(numberOfRows));
            output.Append(AddDashes(numberOfRows));

            for (int row = 0; row < numberOfRows; row++)
            {
                output.AppendFormat("{0,-2} | ", row);

                for (int col = 0; col < numberOfCols; col++)
                {
                    var currentCell = matrix.Field[row, col];

                    if (!currentCell.IsOpen)
                    {
                        output.AppendFormat("{0, -3}", UnrevealedCellCharacter);
                    }
                    else if (!currentCell.IsBoomb)
                    {
                        if (currentCell.NumberOfMines != 0)
                        {
                            output.AppendFormat("{0, -3}", currentCell.NumberOfMines);
                        }
                        else
                        {
                            output.AppendFormat("{0, -3}", currentCell.NumberOfMines); //Represent zero cells as empty space character
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
            Console.WriteLine(output.ToString());
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
                output.AppendFormat("{0, -3}", i);
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

            output.AppendLine(new string('-', (rows * 3) + 3));

            return output;
        }
    }
}
