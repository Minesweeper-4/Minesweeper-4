namespace NunitTests
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Enumerations;
    using Minesweeper.Logic.Draw;
    using NUnit.Framework;

    /// <summary>
    /// Test Ran on the 'turn' command
    /// </summary>
    [TestFixture]
    public class TurnCommandTests
    {
        /// <summary>
        /// Initializes a new matrix
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
        /// Check whether the 'turn' command 
        /// </summary>
        [Test]
        public void ShouldNotThrowWhenValidTurnCommand()
        {
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);
            game.ExecuteCommand("start small");

            Assert.DoesNotThrow(() => game.ExecuteCommand("turn 0 0"));
        }
    }
}
