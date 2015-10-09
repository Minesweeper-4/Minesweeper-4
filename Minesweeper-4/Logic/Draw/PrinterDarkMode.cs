namespace Minesweeper.Logic.Draw
{
    using Minesweeper.Interfaces;
    using System;
    using System.Text;

    /// <summary>
    /// Expands the Decorator, and adds e switch mode of color black background, and white foreground
    /// </summary>
    public class PrinterDarkMode : PrinterDecorator
    {
        /// <summary>
        /// Applying proper colors for the Console 
        /// </summary>
        public override void Apply()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Print matrix
        /// </summary>
        /// <param name="matrix">Input matrix to print</param>
        /// <param name="player">Input player</param>
        public override void PrintMatrix(IMatrix matrix, IPlayer player)
        {
            Console.Clear();
            var output = new StringBuilder();
            output.AppendLine("Dark Mode");
            output.AppendLine(this.GetPrintFrame(matrix, player));
            this.PrintLine(output.ToString());
        }
    }
}
