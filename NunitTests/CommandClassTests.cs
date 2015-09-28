using Minesweeper.Engine;
using NUnit.Framework;
using System.Collections.Generic;

namespace NunitTests
{
    [TestFixture]
    public class CommandClassTests
    {
        [Test]
        public void CommandConstructorAndPropertiesGetterAndSetterTesting()
        {
            string word = "command";
            Command command = new Command(word);

            string expectedName = "Command";
            IList<string> expectedParameters = new List<string>();
            command.Name = expectedName;
            command.Parameters = expectedParameters;

            Assert.AreEqual(expectedName, command.Name, "Expected and actual command name are not equal!");
            Assert.AreEqual(expectedParameters, command.Parameters, "Expected and actual parameters list are not equal!");
        }

        [TestCase("deystvay 1 2")]
        public void CommandTranslateInputMethodWorksProper(string input)
        {
            Command command = new Command(input);
            List<string> expectedParameters = new List<string> {"1", "2"};

            Assert.AreEqual("deystvay", command.Name);
            Assert.AreEqual(expectedParameters, command.Parameters);
        }
    }
}