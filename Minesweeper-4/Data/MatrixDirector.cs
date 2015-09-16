namespace Minesweeper.Data
{
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
        }
    }
}
