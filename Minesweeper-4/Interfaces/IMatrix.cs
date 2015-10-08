namespace Minesweeper.Interfaces
{
    /// <summary>
    /// Interface for setting the desired fields, rows, and cols of the maatrix
    /// </summary>
    public interface IMatrix
    {
        int Rows { get; }

        int Cols { get; }

        ICell[,] Field { get; set; }
    }
}
