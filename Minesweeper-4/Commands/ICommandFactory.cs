namespace Minesweeper.Commands
{
    /// <summary>
    /// Implements the base for the factory pattern, where the command is taken from the use in order to be transferred for processing
    /// </summary>
    public interface ICommandFactory
    {
        Command GetCommand(CommandInfo commandInfo);
    }
}
