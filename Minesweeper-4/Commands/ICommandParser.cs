namespace Minesweeper.Commands
{
    /// <summary>
    /// Interface set to parse the console input
    /// </summary>
    public interface ICommandParser
    {
        /// <summary>
        /// Method for parsing input command
        /// </summary>
        /// <param name="input">Input string for the command</param>
        /// <returns>Returns object holding command information</returns>
        ICommandInfo Parse(string input);
    }
}
