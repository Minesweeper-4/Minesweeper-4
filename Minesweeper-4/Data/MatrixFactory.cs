namespace Minesweeper.Data
{
    using Minesweeper.Interfaces;

    public class MatrixFactory
    {
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