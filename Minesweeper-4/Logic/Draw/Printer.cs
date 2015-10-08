namespace Minesweeper.Logic.Draw
{
    using Minesweeper.Interfaces;

    /// <summary>
    /// Sets the obligatory properties for printing the matrix on the console
    /// </summary>
    public abstract class Printer
    {
        public abstract void PrintLine(string message);

        public abstract void PrintMatrix(IMatrix matrix, IPlayer player);

        public abstract string GetPrintFrame(IMatrix matrix, IPlayer player);
    }
}
