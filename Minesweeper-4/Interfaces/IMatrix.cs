namespace Minesweeper.Interfaces
{
    /// <summary>
    /// Interface for setting the desired fields, rows, and cols of the maatrix
    /// </summary>
    public interface IMatrix
    {
        /// <summary>
        /// Number of rows of the matrix.
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// Number of columns in the matrix.
        /// </summary>
        int Cols { get; }

        /// <summary>
        /// Matrix field holding collection of the matrix cells.
        /// </summary>
        ICell[,] Field { get; set; }
    }
}
