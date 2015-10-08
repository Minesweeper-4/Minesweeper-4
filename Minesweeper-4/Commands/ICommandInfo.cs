namespace Minesweeper.Commands
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface, used for storing the names of the commands and set them as part of a list
    /// </summary>
    public interface ICommandInfo
    {
        /// <summary>
        /// Property holding the name of the command.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Collection of the command parameters if any.
        /// </summary>
        IList<string> Params { get; }
    }
}
