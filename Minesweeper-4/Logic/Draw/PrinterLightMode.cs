namespace Minesweeper.Logic.Draw
{
    using System;
    using System.Text;

    /// <summary>
    /// Expands the Decorator, and adds e switch mode of color  white background, and black foreground
    /// </summary>
    public class PrinterLightMode : PrinterDecorator
    {
        /// <summary>
        /// Applying proper colors for the Console 
        /// </summary>
        public override void Apply()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Print matrix
        /// </summary>
        /// <param name="matrix">Input matrix to print</param>
        /// <param name="player">Input player</param>
        public override void PrintMatrix(Interfaces.IMatrix matrix, Interfaces.IPlayer player)
        {
            Console.Clear();
            var output = new StringBuilder();
            output.AppendLine("Light Mode");
            output.AppendLine(this.GetPrintFrame(matrix, player));
            this.PrintLine(output.ToString());
        }
    }
}
