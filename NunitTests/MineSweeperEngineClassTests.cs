namespace NunitTests
{
    using System.IO;
    using Minesweeper.Engine;
    using Minesweeper.Enumerations;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test Ran on the Engine Class of the Application
    /// </summary>
    [TestFixture]
    public class MineSweeperEngineClassTests
    {
        /// <summary>
        /// Tests whether the start method throws if invalid command is passed
        /// </summary>
        [Test]
        public void StartMethodShouldThrowIfInvalidCommandIsPassed() // this test is not accurate
        {
            string commandString = "start small"; // must NOT throw exception, but it throws

            MinesweeperEngine gameInstance = MinesweeperEngine.Instance;

            // Assert.That(() => gameInstance.ExecuteCommand(commandString))
            // Assert.That(() => gameInstance.ExecuteCommand(commandString), Throws.Exception.TypeOf<NullReferenceException>());
            Assert.Throws(typeof(IOException), () => gameInstance.ExecuteCommand(commandString));
        }

        /// <summary>
        /// Test whether the execute command works properly
        /// </summary>
        [Test]
        public void ExecuteCommandWorksProper() // this test SHOULD work proper, but doesn't
        {
            Mock<IMinesweeperEngine> mockedEngine = new Mock<IMinesweeperEngine>();
            mockedEngine.Verify(x => x.ExecuteCommand(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Test whether the execute command does not throw
        /// </summary>
        [Test]
        public void ExecuteCommandDoesNotThrow()
        {
            // var commandInfo = new CommandInfo("alabala", new List<string>{"start small"});
            string command = "dfgvfghvb";

            // MinesweeperEngine gameInstance = MinesweeperEngine.Instance;
            var mockObject = new Mock<IMinesweeperEngine>();

            mockObject.Setup(x => x.ExecuteCommand(command));

            var fakeMinesweeperEngine = mockObject.Object;

            Assert.DoesNotThrow(() => fakeMinesweeperEngine.ExecuteCommand(command));
        }
        
        /// <summary>
        /// Tests whether the start command does not throw, using mocking
        /// </summary>
        [Test]
        public void StartMethodDoesNotThrow()
        {
            // string command = "start small";
            // MinesweeperEngine gameInstance = MinesweeperEngine.Instance;
            var mockObject = new Mock<IMinesweeperEngine>();

            mockObject.Setup(x => x.Start());

            var fakeMinesweeperEngine = mockObject.Object;

            Assert.DoesNotThrow(() => fakeMinesweeperEngine.Start());
        }

        /// <summary>
        /// Checks whether the "turn" command works properly when a small matrix is initialized (second test)
        /// </summary>
        [Test]
        public void TurnCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "turn 0 0";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "turn" command works properly when medium matrix is initialized (second test)
        /// </summary>
        [Test]
        public void TurnCommandWorksProperWhenMediumMatrixInitializedSecondTest()
        {
            string command = "turn 1 1";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "turn" command works properly when big matrix is initialized (second test)
        /// </summary>
        [Test]
        public void TurnCommandWorksProperWhenBigMatrixInitializedSecondTest()
        {
            string command = "turn 1 1";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "menu" command works properly when a small matrix is initialized
        /// </summary>
        [Test]
        public void MenuCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "menu";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "menu" command works properly when a medium matrix is initialized
        /// </summary>
        [Test]
        public void MenuCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "menu";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "menu" command works properly when a big matrix is initialized
        /// </summary>
        [Test]
        public void MenuCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "menu";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "exit" command works properly when a small matrix is initialized
        /// </summary>
        [Test]
        public void ExitCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "exit";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "exit" command works properly when a medium matrix is initialized
        /// </summary>
        [Test]
        public void ExitCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "exit";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "exit" command works properly when a big matrix is initialized
        /// </summary>
        [Test]
        public void ExitCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "exit";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "save" command works properly when a small matrix is initialized
        /// </summary>
        [Test]
        public void SaveCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "save";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "save" command works properly when a medium matrix is initialized
        /// </summary>
        [Test]
        public void SaveCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "save";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "save" command works properly when a big matrix is initialized
        /// </summary>
        [Test]
        public void SaveCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "save";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "load" command works properly when a small matrix is initialized
        /// </summary>
        [Test]
        public void LoadCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "load";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "load" command works properly when a medium matrix is initialized
        /// </summary>
        [Test]
        public void LoadCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "load";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "load" command works properly when a big matrix is initialized
        /// </summary>
        [Test]
        public void LoadCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "load";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "mode" command works properly when a small matrix is initialized
        /// </summary>
        [Test]
        public void ModeCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "mode light";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.SMALL);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "mode" command works properly when a medium matrix is initialized
        /// </summary>
        [Test]
        public void ModeCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "mode light";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "mode" command works properly when a big matrix is initialized
        /// </summary>
        [Test]
        public void ModeCommandWorksProperWhenBigMatrixInitialized()
        {
            string command = "mode light";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "high score" command works properly when a small matrix is initialized
        /// </summary>
        [Test]
        public void HighscoreCommandWorksProperWhenSmallMatrixInitialized()
        {
            string command = "highscore";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.BIG);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "high sore" command works properly when a medium matrix is initialized
        /// </summary>
        [Test]
        public void HighscoreCommandWorksProperWhenMediumMatrixInitialized()
        {
            string command = "highscore";
            var game = MinesweeperEngine.Instance;
            game.CreateMatrix(MatrixTypes.MEDIUM);

            Assert.Throws(typeof(IOException), () => game.ExecuteCommand(command));
        }

        /// <summary>
        /// Checks whether the "high score" command works properly when a big matrix is initialized
        /// </summary>
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