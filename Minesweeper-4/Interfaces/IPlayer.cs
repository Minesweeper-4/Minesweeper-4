using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Interfaces
{
    interface IPlayer
    {
        string NickName { get; set; }

        int Scores { get; set; }        
    }
}
