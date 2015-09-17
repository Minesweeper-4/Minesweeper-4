namespace Minesweeper.Logic.Sorter
{
    using Minesweeper.Data.Player;
    using Minesweeper.Interfaces;
    using System.Collections.Generic;

    abstract class SortStrategy
    {
        public abstract List<Player> Sort(IList<Player> list);
    }
}
