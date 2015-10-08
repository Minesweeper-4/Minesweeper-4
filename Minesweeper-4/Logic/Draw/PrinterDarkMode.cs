namespace Minesweeper.Logic.Draw
{
    using System;
    using System.Text;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Expands the Decorator, and adds e switch mode of color black background, and white foreground
    /// </summary>
    public class PrinterDarkMode : PrinterDecorator
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
