namespace Minesweeper.Interfaces
{
    /// <summary>
    /// Set the desired states for the different cells
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Checks if a cell is opened.
        /// </summary>
        bool IsOpen { get; set; }

        /// <summary>
        /// Checks if a cell has a bomb.
        /// </summary>
        bool IsBomb { get; set; }

        /// <summary>
        /// Holds information for the number of mines in the cell.
        /// </summary>
        int NumberOfMines { get; set; }
    }
}
