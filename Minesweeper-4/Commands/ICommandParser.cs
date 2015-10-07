namespace Minesweeper.Commands
{
    /// <summary>
    /// Interface set to parse the console input
    /// </summary>
    public interface ICommandParser
    {
        ICommandInfo Parse(string input);
    }
}
