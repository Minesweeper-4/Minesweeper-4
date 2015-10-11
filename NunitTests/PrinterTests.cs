namespace NunitTests
{
    using System;
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Enumerations;
    using Minesweeper.Logic.Draw;
    using NUnit.Framework;

    /// <summary>
    /// Tests Ran on the Printer
    /// </summary>
    [TestFixture]
    public class PrinterTests
    {
        /// <summary>
        /// Checks whether the expected print frame not to return an empty string
        /// </summary>
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

        /// <summary>
        /// Expects that the printer line will not throw
        /// </summary>
        [Test]
        public void ExpectPrintLineNotToThrow()
        {
            var printer = new StandardPrinter();
            var message = "testMessage";

            Assert.DoesNotThrow(() => printer.PrintLine(message));
        }

        /// <summary>
        /// Expects the print Matrix not to throw
        /// </summary>
        [Test]
        [Ignore]
        public void ExpectPrintMatrixNotToThrow()
        {
            var matrix = new MatrixFactory().CreateMatrix(MatrixTypes.BIG);
            var player = new Player();

            var printer = new StandardPrinter();

            Assert.DoesNotThrow(() => printer.PrintMatrix(matrix, player));
        }

        /// <summary>
        /// Expects the dark mode to work properly on the background
        /// </summary>
        [Test]
        public void ExpectPrinterDarkModeToApplayBlackBackgroundToConsole()
        {
            var darkPrinter = new PrinterDarkMode();
            darkPrinter.Apply();
            var resultColor = Console.BackgroundColor;

            Assert.AreEqual(ConsoleColor.Black, resultColor);
        }

        /// <summary>
        /// Expects the dark mode to work properly on the foreground
        /// </summary>
        [Test]
        public void ExpectPrinterDarkModeToApplayGrayForegroundColorToConsole()
        {
            var darkPrinter = new PrinterDarkMode();
            darkPrinter.Apply();
            var resultColor = Console.ForegroundColor;

            Assert.AreEqual(ConsoleColor.Gray, resultColor);
        }

        /// <summary>
        /// Expects the light mode to work properly on the background
        /// </summary>
        [Test]
        public void ExpectPrinterLightModeToApplayWhiteBackgroundToConsole()
        {
            var lightPrinter = new PrinterLightMode();
            lightPrinter.Apply();

            var resultColor = Console.BackgroundColor;

            Assert.AreEqual(ConsoleColor.Black, resultColor);
        }

        /// <summary>
        /// Expects the light mode to work properly on the foreground
        /// </summary>
        [Test]
        public void ExpectPrinterLightModeToApplayBlackForegroundColorToConsole()
        {
            var lightPrinter = new PrinterLightMode();
            lightPrinter.Apply();

            var resultColor = Console.ForegroundColor;

            Assert.AreEqual(ConsoleColor.Gray, resultColor);
        }

        /// <summary>
        /// Expects the set of the printer not to throw
        /// </summary>
        [Test]
        public void ExpectSetPrinterNotToThrow()
        {
            var lightPrinter = new PrinterLightMode();
            var darkPrinter = new PrinterDarkMode();

            Assert.DoesNotThrow(() => lightPrinter.SetPrinter(darkPrinter));
        }

        /// <summary>
        /// Expects the printer line of the decorator not to throw
        /// </summary>
        [Test]
        public void ExpectPrintLineOfPrinterDecoratorNotToThrow()
        {
            var lightPrinter = new PrinterLightMode();
            var standartPrinter = new StandardPrinter();

            lightPrinter.SetPrinter(standartPrinter);
            var message = "test message";

            Assert.DoesNotThrow(() => lightPrinter.PrintLine(message));
        }

        /// <summary>
        /// Expects the getter of the print frame of the decorator not to be an empty string
        /// </summary>
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
