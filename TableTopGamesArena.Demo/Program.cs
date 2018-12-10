using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TabletopGamesArena.Core;
using TabletopGamesArena.Core.Games;
using TabletopGamesArena.Core.Modules;

namespace TabletopGamesArena.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            RunArena();

            Console.ReadKey();
        }

        private static void RunArena()
        {
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Run();
        }
    }
}
