namespace NunitTests
{
    using Minesweeper.Data;
    using Minesweeper.Interfaces;
    using NUnit.Framework;

    /// <summary>
    /// Test ran on Matrix Memento Pattern
    /// </summary>
    [TestFixture]
    public class MatrixMementoClassTests
    {
        /// <summary>
        /// Checks whether when arguments are passed, memento constructs a proper matrix
        /// </summary>
        /// <param name="rows">number of rows are passed as arguments</param>
        /// <param name="cols">number of columns are passed as arguments</param>
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(10, 10)]
        [TestCase(1, 5)]
        [TestCase(5, 2)]
        public void MatrixMementoConstructProperMatrix(int rows, int cols)
        {
            ICell[,] field = new ICell[rows, cols];

            MatrixMemento memento = new MatrixMemento(field);

            Assert.AreEqual(field.GetLength(0), memento.Field.GetLength(0), "Memento field expected rows are not equal to actual rows"); 
            Assert.AreEqual(field.GetLength(1), memento.Field.GetLength(1), "Memento field expected cols are not equal to actual cols");
        }

        /// <summary>
        /// Test what happens if an empty constructor is passed to the memento
        /// </summary>
        [Test]
        public void MatrixMementoEmptyConstructorTest()
        {
            MatrixMemento memento = new MatrixMemento();

            Assert.IsInstanceOf(typeof(MatrixMemento), memento, "Memento instance doesn't exist");
        }
    }
}