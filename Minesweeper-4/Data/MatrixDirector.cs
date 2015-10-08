namespace Minesweeper.Data
{
    /// <summary>
    /// Implements the Builder Design Pattern and set the stages for building the matrix
    /// </summary>
    public class MatrixDirector
    {
        /// <summary>
        /// Empty Constructor for the MatrixDirector class.
        /// </summary>
        public MatrixDirector()
        {
        }

        /// <summary>
        /// Define the steps for constructing new Matrix. 
        /// </summary>
        /// <param name="builder">Take a MatrixBuilder class and make him construct the matrix.</param>
        public void Construct(MatrixBuilder builder)
        {
            builder.SetField();
            builder.InitCells();
            builder.SetBombs();
            builder.SetNumberOfMines();
        }
    }
}
