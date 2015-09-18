using Minesweeper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic.Draw
{
    public abstract class PrinterDecorator : Printer
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
            throw new NotImplementedException();
        }

        public abstract void Apply();

        public override string GetPrintFrame(IMatrix matrix, IPlayer player)
        {
            return this.printer.GetPrintFrame(matrix, player);
        }
    }
}
