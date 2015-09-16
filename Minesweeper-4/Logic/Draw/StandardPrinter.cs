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

        public StandardPrinter()
        {
               
        }

        public override void Print(IMatrix matrix)
        {
            Console.Clear();

            var numberOfRows = matrix.Field.GetLength(0);
            var numberOfCols = matrix.Field.GetLength(1);
            var currentRow = new StringBuilder();

            currentRow.AppendLine("    0 1 2 3 4 5 6 7 8 9");
            currentRow.AppendLine("   ---------------------");

            for (int row = 0; row < numberOfRows; row++)
            {
                currentRow.AppendFormat("{0} | ", row);

                for (int col = 0; col < numberOfCols; col++)
                {
                    if (!matrix.Field[row, col].IsOpen)
                    {
                        currentRow.AppendFormat("{0} ", UnrevealedCellCharacter);
                    }
                    else
                    {
                        currentRow.AppendFormat("{0} ", '1');

                    }
                }

                currentRow.Append("|\n");
            }
            currentRow.Append("   ---------------------\n");
            Console.WriteLine(currentRow.ToString());
        }
    }
}
