namespace Minesweeper.Data
{
    /// <summary>
    /// Implements the Builder Design Pattern and set the stages for building the matrix
    /// </summary>
    public class MatrixDirector
    {
        public MatrixDirector()
        {
        }

        public void Construct(MatrixBuilder builder)
        {
            builder.SetField();
            builder.InitCells();
            builder.SetBombs();
            builder.SetNumberOfMines();
        }
    }
}
