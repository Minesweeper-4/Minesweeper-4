namespace Minesweeper.Interfaces
{
    public interface ICell
    {
        bool IsOpen { get; set; }
        bool IsBomb { get; set; }
        int NumberOfMines { get; set; }
    }
}
