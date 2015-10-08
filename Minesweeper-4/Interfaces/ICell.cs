namespace Minesweeper.Interfaces
{
    /// <summary>
    /// Set the desired states for the different cells
    /// </summary>
    public interface ICell
    {
        bool IsOpen { get; set; }

        bool IsBomb { get; set; }

        int NumberOfMines { get; set; }
    }
}
