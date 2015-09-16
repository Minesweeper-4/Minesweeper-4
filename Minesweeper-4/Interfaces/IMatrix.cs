namespace Minesweeper.Interfaces
{
    public interface IMatrix
    {
        int Rows { get; }
        int Cols { get; }
        ICell[,] Field { get; set; }
    }
}
