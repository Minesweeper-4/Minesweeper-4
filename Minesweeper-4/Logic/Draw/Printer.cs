namespace Minesweeper.Logic.Draw
{
    using Minesweeper.Interfaces;

    public abstract class Printer
    {
        public abstract void Print(IMatrix matrix, IPlayer player);
    }
}
