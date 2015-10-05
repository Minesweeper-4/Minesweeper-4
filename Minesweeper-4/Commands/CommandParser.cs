namespace Minesweeper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CommandParser : ICommandParser
    {
        private const char SplitCommandSymbol = ' ';

        public ICommandInfo Parse(string input)
        {
            input.Trim();

            string commandName;
            List<string> commandParameters = new List<string>();
            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);
            if (indexOfFirstSeparator != -1)
            {
                commandName = input.Substring(0, indexOfFirstSeparator);
                commandParameters = input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                commandName = input;
                commandParameters = new List<string>();
            }

            return new CommandInfo(commandName, commandParameters);
        }
    }
}
