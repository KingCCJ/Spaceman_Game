using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            while (game.DidWin() || game.DidLose() == false)
            {
                game.Display();
                game.Ask();
                if (game.DidWin())
                {
                    break;
                }
                else if (game.DidLose())
                {
                    break;
                }
            }
        }
    }
}
