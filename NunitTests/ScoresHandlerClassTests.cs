using Minesweeper.Data.Player;
using Minesweeper.Logic.Scores;
using NUnit.Framework;
using System;
using System.IO;

namespace NunitTests
{
    [TestFixture]
    public class ScoresHandlerClassTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void ScoresHandlerRecordsListIsUpdatedWhenAddingRecords(int count)
        {
            ScoresHandler scoresHandler = new ScoresHandler();

            int expectedListLength = scoresHandler.Reccords.Count + count;

            for (int i = 0; i < count; i++)
            {
                Player player = new Player(string.Format("Petkan{0}", i), i);
                scoresHandler.AddReccord(player);
            }

            int newListLength = scoresHandler.Reccords.Count;

            Assert.AreEqual(expectedListLength, newListLength, "List of Records are not updated!");
        }
        
        [Test]
        public void ExpectSaveToFileToCreateFileIfTheFileDoesntExist()
        {
            var fileName = "testFile.txt";
            var scoreHandler = new ScoresHandler();

            scoreHandler.SaveToFile(fileName);

            Assert.True(File.Exists(fileName));
            File.Delete(fileName);
        }

        [Test]
        public void ExpectLoadFromFileToCreateFileIfTheFileDoesntExist()
        {
            var fileName = "testFile.txt";
            var scoreHandler = new ScoresHandler();

            scoreHandler.LoadFromFile(fileName);

            Assert.True(File.Exists(fileName));
            File.Delete(fileName);
        }

        [Test]
        public void ExpectLoadFromFileToLoadCorrectList()
        {
            var fileName = "testFile.txt";
            var scoreHandler = new ScoresHandler();
            var playerA = new Player("TestPlayerA", 1);
            var playerB = new Player("TestPlayerB", 2);
            scoreHandler.AddReccord(playerA);
            scoreHandler.AddReccord(playerB);

            scoreHandler.SaveToFile(fileName);

            scoreHandler.LoadFromFile(fileName);

            Assert.AreEqual(2, scoreHandler.Reccords.Count, "The loaded scores are {0}, which is incorect value",
                            scoreHandler.Reccords.Count);

            File.Delete(fileName);
        }
    }
}