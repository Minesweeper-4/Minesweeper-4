using Minesweeper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic.Draw
{
    class PrinterLightTheme : Printer
    {
        protected Printer printer;

        public void SetPrinter(Printer printer)
        {
            this.printer = printer;
        }

        public override void PrintLine(string message)
        {
            this.printer.PrintLine(message);
        }

        public override void PrintMatrix(IMatrix matrix, IPlayer player)
        {
            Console.Clear();
            var output = new StringBuilder();
            output.AppendLine("Light Mode");
            output.AppendLine(this.GetPrintFrame(matrix, player));
            this.PrintLine(output.ToString());
        }

        public void ApplyLightTheme()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public override string GetPrintFrame(IMatrix matrix, IPlayer player)
        {
            return this.printer.GetPrintFrame(matrix, player);
        }
    }
}
