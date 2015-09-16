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

        public override void Print(IMatrix matrix)
        {
            Console.Clear();

            var numberOfRows = matrix.Field.GetLength(0);
            var numberOfCols = matrix.Field.GetLength(1);
            var output = new StringBuilder();

            output.AppendLine("    0 1 2 3 4 5 6 7 8 9");
            output.AppendLine("   ---------------------");

            for (int row = 0; row < numberOfRows; row++)
            {
                output.AppendFormat("{0} | ", row);

                for (int col = 0; col < numberOfCols; col++)
                {
                    var currentCell = matrix.Field[row, col];

                    if (!currentCell.IsOpen)
                    {
                        output.AppendFormat("{0} ", UnrevealedCellCharacter);
                    }
                    else if (!currentCell.IsBoomb)
                    {
                        output.AppendFormat("{0} ", currentCell.NumberOfMines);
                    }
                    else
                    {
                        output.AppendFormat("{0} ", BombCharacter);
                    }
                }

                output.Append("|\n");
            }
            output.Append("   ---------------------\n");
            Console.WriteLine(output.ToString());
        }
    }
}
