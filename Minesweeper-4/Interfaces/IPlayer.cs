using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Interfaces
{
    interface IPlayer
    {
        public string NickName { get; set; }

        public int Scores { get; set; }        
    }
}
