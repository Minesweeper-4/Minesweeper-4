using Minesweeper.Data;
using Minesweeper.Data.Player;
using Minesweeper.Logic.Draw;
using NUnit.Framework;
using System;
using System.Diagnostics;
using Minesweeper.Enumerations;

namespace NunitTests
{
    [TestFixture]
    public class PrinterTests
    {
        [Test]
        public void ExpectGetPrintFrameToReturntNotEmptyString()
        {
            var director = new MatrixDirector();
            var builder = new SmallMatrixBuilder();
            director.Construct(builder);
            var matrix = builder.GetMatrix();

            var player = new Player();

            var printer = new StandardPrinter();

            var result = printer.GetPrintFrame(matrix, player);

            Assert.AreNotEqual(result.Length, 0);
        }

        [Test]
        public void ExpectPrintLineNotToThrow()
        {
            var printer = new StandardPrinter();
            var message = "testMessage";


            Assert.DoesNotThrow(() => printer.PrintLine(message));
        }


        // Console.Clear() breaks that test
        [Test]
        [Ignore]
        public void ExpectPrintMatrixNotToThrow()
        {
            var matrix = new MatrixFactory().CreateMatrix(MatrixTypes.BIG);
            var player = new Player();

            var printer = new StandardPrinter();

            Assert.DoesNotThrow(() => printer.PrintMatrix(matrix, player));
        }

        [Test]
        public void ExpectPrinterDarkModeToApplayBlackBackgroundToConsole()
        {
            var darkPrinter = new PrinterDarkMode();
            darkPrinter.Apply();
            var resultColor = Console.BackgroundColor;

            Assert.AreEqual(ConsoleColor.Black, resultColor);
        }

        [Test]
        public void ExpectPrinterDarkModeToApplayGrayForegroundColorToConsole()
        {
            var darkPrinter = new PrinterDarkMode();
            darkPrinter.Apply();
            var resultColor = Console.ForegroundColor;

            Assert.AreEqual(ConsoleColor.Gray, resultColor);
        }

        [Test]
        public void ExpectPrinterLightModeToApplayWhiteBackgroundToConsole()
        {
            var lightPrinter = new PrinterLightMode();
            lightPrinter.Apply();

            var resultColor = Console.BackgroundColor;

            Assert.AreEqual(ConsoleColor.Black, resultColor);
        }

        [Test]
        public void ExpectPrinterLightModeToApplayBlackForegroundColorToConsole()
        {
            var lightPrinter = new PrinterLightMode();
            lightPrinter.Apply();

            var resultColor = Console.ForegroundColor;

            Assert.AreEqual(ConsoleColor.Gray, resultColor);
        }

        [Test]
        public void ExpectSetPrinterNotToThrow()
        {
            var lightPrinter = new PrinterLightMode();
            var darkPrinter = new PrinterDarkMode();

            Assert.DoesNotThrow(() => lightPrinter.SetPrinter(darkPrinter));
        }

        [Test]
        public void ExpectPrintLineOfPrinterDecoratorNotToThrow()
        {
            var lightPrinter = new PrinterLightMode();
            var standartPrinter = new StandardPrinter();

            lightPrinter.SetPrinter(standartPrinter);
            var message = "test message";

            Assert.DoesNotThrow(() => lightPrinter.PrintLine(message));
        }

        [Test]
        public void ExpectGetPrintFrameOfPrintDecoratorNotToBeEmptyString()
        {
            var matrix = new MatrixFactory().CreateMatrix(MatrixTypes.BIG);

            var player = new Player();

            var printer = new PrinterLightMode();
            var standartPrinter = new StandardPrinter();
            printer.SetPrinter(standartPrinter);

            var result = printer.GetPrintFrame(matrix, player);

            Assert.AreNotEqual(result.Length, 0);
        }
    }
}
