/// <summary>
/// NUnit test based on cell and matrix properties
/// </summary>
namespace NunitTests
{
    using Minesweeper.Data;
    using NUnit.Framework;

    /// <summary>
    /// Test Ran on the Cells of the Matrix
    /// </summary>
    [TestFixture]
    public class CellClassTests
    {
        /// <summary>
        /// Checks whether the cell's properties get and set work properly
        /// </summary>
        [Test]
        public void CellPropertyIsOpenGetterAndSetterWorksProper()
        {
            Cell cell = new Cell();

            bool expectedIsOpen = true;
            cell.IsOpen = expectedIsOpen;

            bool actualIsOpen = cell.IsOpen;

            Assert.AreEqual(expectedIsOpen, actualIsOpen, "Expected and actual value of IsOpen property are not equal");
        }

        /// <summary>
        /// Checks whether bombs cells' properties get and set work properly
        /// </summary>
        [Test]
        public void CellPropertyIsBombGetterAndSetterWorksProper()
        {
            Cell cell = new Cell();

            bool expectedIsBomb = true;
            cell.IsBomb = expectedIsBomb;

            Assert.AreEqual(expectedIsBomb, cell.IsBomb, "Expected and actual value of IsBomb property are not equal");
        }

        /// <summary>
        /// Checks whether cell' numbers of mines work properly
        /// </summary>
        /// <param name="number">Pass a number to check the number of mines</param>
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(10)]
        public void CellPropertyNumberOfMinesGetterAndSetterWorksProper(int number)
        {
            Cell cell = new Cell();

            cell.NumberOfMines = number;

            Assert.AreEqual(number, cell.NumberOfMines, "Expected and actual value of NumberOfMines property are not equal");
        }

        /// <summary>
        /// Check whether the cell constructor makes an instance with the proper values
        /// </summary>
        [Test]
        public void CellConstructorMustConstructInstanceWithProperPropertyValues()
        {
            Cell cell = new Cell();

            Assert.AreEqual(false, cell.IsBomb, "IsBomb initial value must be false;");
            Assert.AreEqual(false, cell.IsOpen, "IsOpen initial value must be false;");
        }
    }
}