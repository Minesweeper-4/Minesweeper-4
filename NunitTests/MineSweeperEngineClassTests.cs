using System.IO;
using Minesweeper.Engine;
using Moq;
using NUnit.Framework;
using Minesweeper.Engine;

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
            //var commandInfo = new CommandInfo("alabala", new List<string>{"start small"});

            string command = "start small";

            //MinesweeperEngine gameInstance = MinesweeperEngine.Instance;

            var mockObject = new Mock<IMinesweeperEngine>();

            mockObject.Setup(x => x.Start());

            var fakeMinesweeperEngine = mockObject.Object;


            Assert.DoesNotThrow(() => fakeMinesweeperEngine.Start());
        }
    }
    
}