namespace NunitTests
{
    using Minesweeper.Data;
    using Minesweeper.Enumerations;
    using Minesweeper.Interfaces;
    using NUnit.Framework;

    /// <summary>
    /// Tests ran on the matrix Factory
    /// </summary>
    [TestFixture]
    public class MatrixFactoryClassTests
    {
        /// <summary>
        /// Checks whether the factory properly returns a small matrix
        /// </summary>
        [Test]
        public void MatrixFactoryReturnsProperSmallMatrix()
        {
            /*MatrixBuilder smallBuilder = new SmallMatrixBuilder();
            int expectedCols = smallBuilder.Matrix.Cols;
            int expectedRaws = smallBuilder.Matrix.Rows;*/

            int expectedCols = 5;
            int expectedRows = 5;

            MatrixFactory factory = new MatrixFactory();
            IMatrix matrix = factory.CreateMatrix(MatrixTypes.SMALL);

            Assert.AreEqual(expectedCols, matrix.Cols, "Actual number of matrix columns are different from expected");
            Assert.AreEqual(expectedRows, matrix.Cols, "Actual number of matrix rows are different from expected");
        }

        /// <summary>
        /// Checks whether the matrix properly returns a medium matrix
        /// </summary>
        [Test]
        public void MatrixFactoryReturnsProperMediumMatrix()
        {
            int expectedCols = 10;
            int expectedRows = 10;

            MatrixFactory factory = new MatrixFactory();
            IMatrix matrix = factory.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.AreEqual(expectedCols, matrix.Cols, "Actual number of matrix columns are different from expected");
            Assert.AreEqual(expectedRows, matrix.Cols, "Actual number of matrix rows are different from expected");
        }

        /// <summary>
        /// Checks whether the factory properly returns a big matrix
        /// </summary>
        [Test]
        public void MatrixFactoryReturnsProperBigMatrix()
        {
            int expectedCols = 15;
            int expectedRows = 15;

            MatrixFactory factory = new MatrixFactory();
            IMatrix matrix = factory.CreateMatrix(MatrixTypes.BIG);

            Assert.AreEqual(expectedCols, matrix.Cols, "Actual number of matrix columns are different from expected");
            Assert.AreEqual(expectedRows, matrix.Cols, "Actual number of matrix rows are different from expected");
        }

        /// <summary>
        /// Checks whether the matrix properly returns a default matrix
        /// </summary>
        [Test]
        public void MatrixFactoryReturnsProperDefaultMatrix()
        {
            int expectedCols = 5;
            int expectedRows = 5;

            MatrixFactory factory = new MatrixFactory();
            IMatrix matrix = factory.CreateMatrix(default(MatrixTypes));

            Assert.AreEqual(expectedCols, matrix.Cols, "Actual number of matrix columns are different from expected");
            Assert.AreEqual(expectedRows, matrix.Cols, "Actual number of matrix rows are different from expected");
        }
    }
}