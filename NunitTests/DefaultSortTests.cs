using NUnit.Framework;
using System;
using Minesweeper.Logic.Sorter;
using Minesweeper.Data.Player;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace NunitTests
{
    [TestFixture]
    public class DefaultSortTests
    {
        [Test]
        public void DefaultSortMethodSortsProperByScore()
        {
            DefaultSort sorter = new DefaultSort();

            Player first = new Player("Ivan", 2);
            Player second = new Player("Dragan", 1);
            Player third = new Player("Petkan", 0);

            IList<Player> inputPlayers = new List<Player> { first, third, second };

            IList<Player> expectedPlayers = new List<Player> { first, second, third };

            IList<Player> actualPlayers = sorter.Sort(inputPlayers);

            Assert.IsTrue(expectedPlayers.SequenceEqual(actualPlayers),
                "The expected and the result lists of sorted Players are NOT equal!");
        }

        [Test]
        public void DefaultSortMethodSortsProperFirstByScoreSecondByName()
        {
            DefaultSort sorter = new DefaultSort();

            Player first = new Player("Ivan", 2);
            Player second = new Player("Angel", 1);
            Player third = new Player("Angus", 1);

            IList<Player> inputPlayers = new List<Player> { first, third, second };

            IList<Player> expectedPlayers = new List<Player> { first, second, third };

            IList<Player> actualPlayers = sorter.Sort(inputPlayers);

            Assert.IsTrue(expectedPlayers.SequenceEqual(actualPlayers),
                "The expected and the result lists of sorted Players are NOT equal!");
        }
    }
}
