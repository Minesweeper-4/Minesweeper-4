namespace Minesweeper.Commands
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface, used for storing the names of the commands and set them as part of a list
    /// </summary>
    public interface ICommandInfo
    {
        string Name { get; }

        IList<string> Params { get; }
    }
}
