namespace Minesweeper.Logic.Draw
{
    using System;
    using System.Text;

    /// <summary>
    /// Expands the Decorator, and adds e switch mode of color  white background, and black foreground
    /// </summary>
    public class PrinterLightMode : PrinterDecorator
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
            output.AppendLine(this.GetPrintFrame(matrix, player));
            this.PrintLine(output.ToString());
        }
    }
}
