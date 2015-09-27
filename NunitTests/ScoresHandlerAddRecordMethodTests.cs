using Minesweeper.Data.Player;
using Minesweeper.Logic.Scores;
using NUnit.Framework;

namespace NunitTests
{
    [TestFixture]
    public class ScoresHandlerAddRecordMethodTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void WhenAddingOneRecordListIsUpdated(int count)
        {
            ScoresHandler scoresHandler = new ScoresHandler("somepath");

            int expectedListLength = scoresHandler.Reccords.Count + count;

            for (int i = 0; i < count; i++)
            {
                Player player = new Player(string.Format("Petkan{0}", i), i);
                scoresHandler.AddReccord(player);
            }

            int newListLength = scoresHandler.Reccords.Count;

            Assert.AreEqual(expectedListLength, newListLength, "List of Records are not updated!");
        }
    }
}