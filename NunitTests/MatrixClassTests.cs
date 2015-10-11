namespace NunitTests
{
    using Minesweeper.Data;
    using Minesweeper.Interfaces;
    using NUnit.Framework;

    /// <summary>
    /// Tests ran on the matrix
    /// </summary>
    [TestFixture]
    public class MatrixClassTests
    {
        /// <summary>
        /// Check whether the memento save and restore options work properly
        /// </summary>
        [Test]
        public void MatrixSaveMementoAndRestoreMementoMethodsWorkProper()
        {
            ICell[,] fieldExpected = new ICell[3, 7];

            Matrix matrix = new Matrix();

            matrix.Field = fieldExpected;

            MatrixMemento matrixMemento = matrix.SaveMemento();

            matrix.Field = new ICell[12, 18];

            matrix.RestoreMemento(matrixMemento); // Comment this row and the test will fail 

            Assert.AreEqual(fieldExpected.GetLength(0), matrix.Rows, "Matrix SaveMememento and RestoreMememento doesn't work proper"); 
            Assert.AreEqual(fieldExpected.GetLength(1), matrix.Cols, "Matrix SaveMememento and RestoreMememento doesn't work proper");
        }
    }
}