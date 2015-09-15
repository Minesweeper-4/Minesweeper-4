namespace Minesweeper.Interfaces
{
    public interface ICell
    {
        bool IsOpen { get; set; }
        bool IsBoomb { get; set; }
        public int NumberOfMines { get; set; }
    }
}
