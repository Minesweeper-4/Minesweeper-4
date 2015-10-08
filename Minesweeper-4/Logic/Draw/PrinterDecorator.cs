namespace Minesweeper.Logic.Draw
{
    using System;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Uses Decorator Design pattern to implement the printing of the matrix
    /// </summary>
    public abstract class PrinterDecorator : Printer
    {
        private Printer printer;

        public Printer Printer
        {
            get
            {
                return this.printer;
            }

            set
            {
                this.printer = value;
            }
        }

        public void SetPrinter(Printer printer)
        {
            this.Printer = printer;
        }

        public override void PrintLine(string message)
        {
            this.Printer.PrintLine(message);
        }

        public override void PrintMatrix(IMatrix matrix, IPlayer player)
        {
            throw new NotImplementedException();
        }

        public abstract void Apply();

        public override string GetPrintFrame(IMatrix matrix, IPlayer player)
        {
            return this.Printer.GetPrintFrame(matrix, player);
        }
    }
}
