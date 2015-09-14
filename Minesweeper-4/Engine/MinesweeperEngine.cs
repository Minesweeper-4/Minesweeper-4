using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Engine
{
    public class MinesweeperEngine
    {
        public MinesweeperEngine()
        {

        }

        public void Start()
        {
            // TODO Builder

            do
            {
                var command = new Command(Console.ReadLine());
                ReadCommand(command);
            } while (true);
        }

        private void ReadCommand(Command command)
        {
            switch (command.Name)
            {
                case "top":
                    Console.WriteLine("Top");
                    break;
                case "restart":
                    //playground = CreateWhiteBoard();
                    //boomBoard = CreateBombBoard();
                    //PrintBoard(playground);
                    //boomed = false;
                    //welcomeFlag = false;
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    break;
                case "turn":
                    Console.WriteLine(command.Parameters[0]);
                    Console.WriteLine(command.Parameters[1]);
                    //if (boomBoard[rowIndex, columnIndex] != '*')
                    //{
                    //    if (boomBoard[rowIndex, columnIndex] == '-')
                    //    {
                    //        MakeAMove(playground, boomBoard, rowIndex, columnIndex);
                    //        counter++;
                    //    }
                    //    if (MAX_REVEALED_CELLS == counter)
                    //    {
                    //        flag = true;
                    //    }
                    //    else
                    //    {
                    //        PrintBoard(playground);
                    //    }
                    //}
                    //else
                    //{
                    //    boomed = true;


                    //}
                    break;
                default:
                    Console.WriteLine("\nIllegal move!\n");
                    break;

            }
        }
    }
}
