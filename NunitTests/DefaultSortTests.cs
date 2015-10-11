namespace NunitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Minesweeper.Data.Player;
    using Minesweeper.Interfaces;
    using Minesweeper.Logic.Sorter;
    using NUnit.Framework;

    /// <summary>
    /// Tests ran on the sorting algorithm
    /// </summary>
    [TestFixture]
    public class DefaultSortTests
    {
        /// <summary>
        /// Checks whether the sort methods sort properly by score
        /// </summary>
        [Test]
        public void DefaultSortMethodSortsProperByScore()
        {
            DefaultSort sorter = new DefaultSort();

            IPlayer first = new Player("Ivan", 2);
            IPlayer second = new Player("Dragan", 1);
            IPlayer third = new Player("Petkan", 0);

            IList<IPlayer> inputPlayers = new List<IPlayer> { first, third, second };

            IList<IPlayer> expectedPlayers = new List<IPlayer> { first, second, third };

            IList<IPlayer> actualPlayers = sorter.Sort(inputPlayers);

            Assert.IsTrue(expectedPlayers.SequenceEqual(actualPlayers), "The expected and the result lists of sorted Players are NOT equal!");
        }

        /// <summary>
        /// Checks whether the sorting methods sort properly first by Score and then by Name
        /// </summary>
        [Test]
        public void DefaultSortMethodSortsProperFirstByScoreSecondByName()
        {
            DefaultSort sorter = new DefaultSort();

            IPlayer first = new Player("Ivan", 2);
            IPlayer second = new Player("Angel", 1);
            IPlayer third = new Player("Angus", 1);

            IList<IPlayer> inputPlayers = new List<IPlayer> { first, third, second };

            IList<IPlayer> expectedPlayers = new List<IPlayer> { first, second, third };

            IList<IPlayer> actualPlayers = sorter.Sort(inputPlayers);

            Assert.IsTrue(expectedPlayers.SequenceEqual(actualPlayers), "The expected and the result lists of sorted Players are NOT equal!");
        }
    }
}
