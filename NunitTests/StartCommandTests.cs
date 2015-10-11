namespace NunitTests
{
    using System;
    using System.Collections.Generic;
    using Minesweeper.Commands;
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;
    using NUnit.Framework;

    /// <summary>
    /// Test Ran on the start Command
    /// </summary>
    [TestFixture]
    public class StartCommandTests
    {
        /// <summary>
        /// Initializes a new Matrix
        /// </summary>
        private Matrix matrix = new Matrix();

        /// <summary>
        /// Initializes a new player
        /// </summary>
        private Player player = new Player();

        /// <summary>
        /// Initializes a printer
        /// </summary>
        private Printer printer = new StandardPrinter();

        /// <summary>
        /// Tests if invalid command is passed, it throws
        /// </summary>
        [Test]
        public void ShouldThrowWhenInvalidMatrixTypeIsPassed()
        {
            var startCommand = new StartCommand(MinesweeperEngine.Instance, this.matrix, this.player, new MatrixDirector(), new MediumMatrixBuilder(), this.printer);

            ICommandInfo command = new CommandInfo(string.Empty, new List<string>() { "invalid type" });

            Assert.Throws(typeof(ArgumentOutOfRangeException), () => startCommand.Execute(command));
        }

        /// <summary>
        /// Tests whether the method can create different types of matrices
        /// </summary>
        /// <param name="matrixType">the matrix type is passed as an argument</param>
        [TestCase("small")]
        [TestCase("medium")]
        [TestCase("big")]
        public void ShouldBeAbleToCreateMatrixOfDifferentTypes(string matrixType)
        {
            var startCommand = new StartCommand(MinesweeperEngine.Instance, this.matrix, this.player, new MatrixDirector(), new MediumMatrixBuilder(), this.printer);

            ICommandInfo commandInfo = new CommandInfo(string.Empty, new List<string>() { matrixType });

            Assert.DoesNotThrow(() => startCommand.Execute(commandInfo));
        }
    }
}
