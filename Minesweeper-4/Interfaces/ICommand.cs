namespace Minesweeper.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Set the obligatory properties for settign a command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Name of the command.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Collection of the command parameters if any.
        /// </summary>
        IList<string> Parameters { get; }
    }
}
