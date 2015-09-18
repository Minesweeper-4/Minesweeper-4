using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic.Draw
{
    class PrinterLightMode : PrinterDecorator
    {
        public override void Apply()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public override void PrintMatrix(Interfaces.IMatrix matrix, Interfaces.IPlayer player)
        {
            Console.Clear();
            var output = new StringBuilder();
            output.AppendLine("Light Mode");
            output.AppendLine(base.GetPrintFrame(matrix, player));
            base.PrintLine(output.ToString());
        }
    }
}
