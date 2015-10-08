namespace Minesweeper.Logic.Sorter
{
    using System.Collections.Generic;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Set the obligatory property for sorting the records
    /// </summary>
    public abstract class SortStrategy // Without public access modifier can't access class in Test project?!?!
    {
        public abstract List<IPlayer> Sort(IList<IPlayer> list);
    }
}
