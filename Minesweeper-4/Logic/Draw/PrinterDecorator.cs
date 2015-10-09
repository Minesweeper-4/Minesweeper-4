namespace Minesweeper.Logic.Draw
{
    using Minesweeper.Interfaces;
    using System;

    /// <summary>
    /// Uses Decorator Design pattern to implement the printing of the matrix
    /// </summary>
    public abstract class PrinterDecorator : Printer
    {
        private Printer printer;

        /// <summary>
        /// Get or set printer field
        /// </summary>
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

        /// <summary>
        /// Set the Printer property
        /// </summary>
        /// <param name="printer"></param>
        public void SetPrinter(Printer printer)
        {
            this.Printer = printer;
        }

        /// <summary>
        /// Print line of string passed as parameter
        /// </summary>
        /// <param name="message">Input string to print</param>
        public override void PrintLine(string message)
        {
            this.Printer.PrintLine(message);
        }

        // TODO: Check this out

        /// <summary>
        /// Not implemented method 
        /// </summary>
        /// <param name="matrix">Input matrix to print</param>
        /// <param name="player">Input player for ala-bala</param>
        public override void PrintMatrix(IMatrix matrix, IPlayer player)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Apply method
        /// </summary>
        public abstract void Apply();

        /// <summary>
        /// Prints the matrix with player info.
        /// </summary>
        /// <param name="matrix">Current matrix.</param>
        /// <param name="player">Current player.</param>
        /// <returns></returns>
        public override string GetPrintFrame(IMatrix matrix, IPlayer player)
        {
            return this.Printer.GetPrintFrame(matrix, player);
        }
    }
}
