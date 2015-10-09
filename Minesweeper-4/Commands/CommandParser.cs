namespace Minesweeper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class used for parsing the user input and pass the command for processing
    /// </summary>
    internal class CommandParser : ICommandParser
    {
        private const char SplitCommandSymbol = ' ';

        /// <summary>
        /// Method that takes the user input, checks it validity and returns the command in order to be further retrieved
        /// </summary>
        /// <param name="input">User console input</param>
        /// <returns></returns>
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
