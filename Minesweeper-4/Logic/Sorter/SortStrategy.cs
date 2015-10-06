namespace Minesweeper.Logic.Sorter
{
    using Minesweeper.Data.Player;
    using Minesweeper.Interfaces;
    using System.Collections.Generic;

    public abstract class SortStrategy // Without public access modifier can't access class in Test project?!?!
    {
        public abstract List<IPlayer> Sort(IList<IPlayer> list);
    }
}
