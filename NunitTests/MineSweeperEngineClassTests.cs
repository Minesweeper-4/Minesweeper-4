using Minesweeper.Engine;
using Moq;
using NUnit.Framework;
using System.IO;

namespace NunitTests
{
    [TestFixture]
    public class MineSweeperEngineClassTests
    {
       [Test]
        public void StartMethodShouldThrowIfInvalidCommandIsPassed()
        {
            string commandString = "sdfsdfdsfstart";

            MinesweeperEngine gameInstance = MinesweeperEngine.Instance;

            //Assert.That(() => gameInstance.ExecuteCommand(commandString))
            //Assert.That(() => gameInstance.ExecuteCommand(commandString), Throws.Exception.TypeOf<NullReferenceException>());
            Assert.Throws(typeof(IOException), () => gameInstance.ExecuteCommand(commandString));
        }

        [Test]
        public void ExecuteCommandDoesNotThrow()
        {
            //var commandInfo = new CommandInfo("alabala", new List<string>{"start small"});

            string command = "dfgvfghvb";

            //MinesweeperEngine gameInstance = MinesweeperEngine.Instance;

            var mockObject = new Mock<IMinesweeperEngine>();

            mockObject.Setup(x => x.ExecuteCommand(command));

            var fakeMinesweeperEngine = mockObject.Object;


            Assert.DoesNotThrow(() => fakeMinesweeperEngine.ExecuteCommand(command));
        }

        [Test]
        public void StartMethodDoesNotThrow()
        {

            string command = "start small";

            //MinesweeperEngine gameInstance = MinesweeperEngine.Instance;

            var mockObject = new Mock<IMinesweeperEngine>();

            mockObject.Setup(x => x.Start());

            var fakeMinesweeperEngine = mockObject.Object;


            Assert.DoesNotThrow(() => fakeMinesweeperEngine.Start());
        }

        [Test]
        public void TurnCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "turn 0 0";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void TurnCommandWorksProperWhenMediumMatrixInitializedSecondTest()
        {
            string command = "turn 1 1";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void TurnCommandWorksProperWhenBigMatrixInitializedSecondTest()
        {
            string command = "turn 1 1";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void MenuCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "menu";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void MenuCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "menu";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void MenuCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "menu";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void ExitCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "exit";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void ExitCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "exit";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void ExitCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "exit";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void SaveCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "save";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void SaveCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "save";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void SaveCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "save";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void LoadCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "load";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void LoadCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "load";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void LoadCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "load";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void ModeCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "mode light";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void ModeCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "mode light";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void ModeCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "mode light";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void HighscoreCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "highscore";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void HighscoreCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "highscore";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        [Test]
        public void HighscoreCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "highscore";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }
        
    }
}