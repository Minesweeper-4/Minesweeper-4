using NUnit.Framework;
using Minesweeper.Data;
using Minesweeper.Interfaces;

namespace NunitTests
{
    [TestFixture]
    public class MatrixMementoClassTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(10, 10)]
        [TestCase(1, 5)]
        [TestCase(5, 2)]
        public void MatrixMementoConstructProperMatrix(int rows, int cols)
        {
            ICell[,] field = new ICell[rows, cols];

            MatrixMemento memento = new MatrixMemento(field);

            Assert.AreEqual(field.GetLength(0), memento.Field.GetLength(0),
                "Memento field expected rows are not equal to actual rows"); 
            Assert.AreEqual(field.GetLength(1), memento.Field.GetLength(1),
                "Memento field expected cols are not equal to actual cols");
        }

        [Test]
        public void MatrixMementoEmptyConstructorTest()
        {
            MatrixMemento memento = new MatrixMemento();

            Assert.IsInstanceOfType(typeof(MatrixMemento), memento, "Memento instance doesn't exist");
        }
    }
}