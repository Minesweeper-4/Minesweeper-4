using Minesweeper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic.Draw
{
    public class PrinterDarkMode:PrinterDecorator
    {
        public override void Apply()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void PrintMatrix(IMatrix matrix, Interfaces.IPlayer player)
        {
            Console.Clear();
            var output = new StringBuilder();
            output.AppendLine("Dark Mode");
            output.AppendLine(this.GetPrintFrame(matrix, player));
            this.PrintLine(output.ToString());
        }
    }
}
