namespace Minesweeper.Logic.Draw
{
    using Minesweeper.Interfaces;

    public abstract class Printer
    {
        public abstract void PrintLine(string message);
        public abstract void PrintMatrix(IMatrix matrix, IPlayer player);
    }
}
