namespace Minesweeper.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Set the obligatory properties for settign a command
    /// </summary>
    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
