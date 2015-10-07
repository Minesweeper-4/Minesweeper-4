using Minesweeper.Data;
using Minesweeper.Data.Player;
using Minesweeper.Engine;
using Minesweeper.Logic.Draw;
using NUnit.Framework;


namespace NunitTests
{
    [TestFixture]
    public class TurnCommandTests
    {
        private Matrix matrix = new Matrix();
        private Player player = new Player();
        private Printer printer = new StandardPrinter();

        [Test]
        public void ShouldNotThrowWhenValidTurnCommand()
        {
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);
            game.ExecuteCommand("start small");

            Assert.DoesNotThrow(()=>game.ExecuteCommand("turn 0 0"));
        }
    }
}
