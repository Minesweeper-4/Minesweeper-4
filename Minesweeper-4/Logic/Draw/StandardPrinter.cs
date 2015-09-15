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

            for (int row = 0; row < numberOfRows; row++)
            {
                var currentRow = new StringBuilder();

                for (int col = 0; col < numberOfCols; col++)
                {
                    if (!matrix.Field[row, col].IsOpen)
                    {
                        currentRow.Append(UnrevealedCellCharacter);
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
