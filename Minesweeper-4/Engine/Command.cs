namespace Minesweeper.Engine
{
    using Minesweeper.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Command : ICommand
    {
        private const char SplitCommandSymbol = ' ';

        private string name;
        private IList<string> parameters;

        public Command(string input)
        {
            this.TranslateInput(input);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            set
            {
                this.parameters = value;
            }
        }

        private void TranslateInput(string input)
        {
            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);

            if (indexOfFirstSeparator != -1)
            {
                this.Name = input.Substring(0, indexOfFirstSeparator);
                this.Parameters = input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                this.Name = input;
                this.Parameters = new List<string>();
            }
        }
    }
}
