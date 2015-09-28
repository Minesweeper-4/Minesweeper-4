using Minesweeper.Data;
using NUnit.Framework;

namespace NunitTests
{
    [TestFixture]
    public class CellClassTests
    {
        [Test]
        public void CellPropertyIsOpenGetterAndSetterWorksProper()
        {
            Cell cell = new Cell();

            bool expectedIsOpen = true;
            cell.IsOpen = expectedIsOpen;

            bool actualIsOpen = cell.IsOpen;

            Assert.AreEqual(expectedIsOpen, actualIsOpen,
                "Expected and actual value of IsOpen property are not equal");
        }

        [Test]
        public void CellPropertyIsBombGetterAndSetterWorksProper()
        {
            Cell cell = new Cell();

            bool expectedIsBomb = true;
            cell.IsBomb = expectedIsBomb;

            Assert.AreEqual(expectedIsBomb, cell.IsBomb,
                "Expected and actual value of IsBomb property are not equal");
        }

        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(10)]
        public void CellPropertyNumberOfMinesGetterAndSetterWorksProper(int number)
        {
            Cell cell = new Cell();

            cell.NumberOfMines = number;

            Assert.AreEqual(number, cell.NumberOfMines,
                "Expected and actual value of NumberOfMines property are not equal");
        }

        [Test]
        public void CellConstructorMustConstructInstanceWithProperPropertyValues()
        {
            Cell cell = new Cell();

            Assert.AreEqual(false, cell.IsBomb, "IsBomb initial value must be false;");
            Assert.AreEqual(false, cell.IsOpen, "IsOpen initial value must be false;");
        }
    }
}