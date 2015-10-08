namespace Minesweeper.Data
{
    using Minesweeper.Interfaces;

    /// <summary>
    /// Set the basic construction for building the different matrix sizes
    /// </summary>
    public class MatrixFactory
    {
        /// <summary>
        /// Create a different matrix depending of the input parameter.
        /// </summary>
        /// <param name="matrixType">Enumeration MatrixType - there are Big, Small and Medium matrix.</param>
        /// <returns>Returns a new instance of matrix.</returns>
        public IMatrix CreateMatrix(MatrixTypes matrixType)
        {
            var director = new MatrixDirector();
            MatrixBuilder builder;

            switch (matrixType)
            {
                case MatrixTypes.SMALL:
                    builder = new SmallMatrixBuilder();
                    break;
                case MatrixTypes.MEDIUM:
                    builder = new MediumMatrixBuilder();
                    break;
                case MatrixTypes.BIG:
                    builder = new BigMatrixBuilder();
                    break;
                default:
                    builder = new SmallMatrixBuilder();
                    break;
            }

            director.Construct(builder);

            return builder.GetMatrix();
        }
    }
}