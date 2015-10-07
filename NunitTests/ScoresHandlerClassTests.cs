using Minesweeper.Data.Player;
using Minesweeper.Logic.Scores;
using NUnit.Framework;
using System;

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
        [Ignore]
        public void ThrowExceptionWhenSettingNullStoringPath()
        {
            string storingPath = null;

            Assert.Throws(typeof(ArgumentNullException), () => new ScoresHandler());
        }

        [Test]
        [Ignore]
        public void ThrowExceptionWhenSettingEmptyStringStoringPath()
        {
            string storingPath = string.Empty;

            Assert.Throws(typeof(ArgumentNullException), () => new ScoresHandler());
        }
    }
}