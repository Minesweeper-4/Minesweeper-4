using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Commands
{
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
