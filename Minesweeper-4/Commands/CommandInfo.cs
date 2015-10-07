namespace Minesweeper.Commands
{
    using System.Collections.Generic;

    /// <summary>
    /// Inherits the interface and sets a constuctod for declaration of the desired parameters of the commands info
    /// </summary>
    public class CommandInfo : ICommandInfo
    {
        private string name;
        private IList<string> parameters;

        public CommandInfo(string name, IList<string> parameters)
        {
            this.Name = name;
            this.Params = parameters;
        }

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
