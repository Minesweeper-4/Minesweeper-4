namespace Minesweeper.Commands
{
    using System.Collections.Generic;

    /// <summary>
    /// Inherits the interface and sets a constructor for declaration of the desired parameters of the commands info
    /// </summary>
    public class CommandInfo : ICommandInfo
    {
        private string name;
        private IList<string> parameters;

        /// <summary>
        /// Object holding information for the command
        /// </summary>
        /// <param name="name">The namo of the command</param>
        /// <param name="parameters">Collection with the command parameters if any</param>
        public CommandInfo(string name, IList<string> parameters)
        {
            this.Name = name;
            this.Params = parameters;
        }

        /// <summary>
        /// Command name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string Name
        {
            get 
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Collection of the command parameters
        /// </summary>
        public IList<string> Params
        {
            get
            {
                return this.parameters;
            }

            private set
            {
                this.parameters = value;
            }
        }
    }
}
