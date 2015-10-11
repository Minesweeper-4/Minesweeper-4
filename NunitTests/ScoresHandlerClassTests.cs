namespace NunitTests
{
    using System.IO;
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Scores;
    using NUnit.Framework;

    /// <summary>
    /// Tests Ran on the Score Handler
    /// </summary>
    [TestFixture]
    public class ScoresHandlerClassTests
    {
        /// <summary>
        /// Tests whether the score handler record list updates properly when some records are added
        /// </summary>
        /// <param name="count">pass the counter as parameter</param>
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
        
        /// <summary>
        /// Checks whether a file is created, if there is no such file, when saving
        /// </summary>
        [Test]
        public void ExpectSaveToFileToCreateFileIfTheFileDoesntExist()
        {
            var fileName = "testFile.txt";
            var scoreHandler = new ScoresHandler();

            scoreHandler.SaveToFile(fileName);

            Assert.True(File.Exists(fileName));
            File.Delete(fileName);
        }

        /// <summary>
        /// Checks whether a file is created, if there is no such file, when loading
        /// </summary>
        [Test]
        public void ExpectLoadFromFileToCreateFileIfTheFileDoesntExist()
        {
            var fileName = "testFile.txt";
            var scoreHandler = new ScoresHandler();

            scoreHandler.LoadFromFile(fileName);

            Assert.True(File.Exists(fileName));
            File.Delete(fileName);
        }

        /// <summary>
        /// Checks whether the correct list is loaded, when load from file is performed
        /// </summary>
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

            Assert.AreEqual(2, scoreHandler.Reccords.Count, "The loaded scores are {0}, which is incorect value", scoreHandler.Reccords.Count);

            File.Delete(fileName);
        }
    }
}