using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopGamesArena.Core.Modules;

namespace TabletopGamesArena.Demo
{
    public class GameRoomScreen
    {
        public GameRoom GameRoom { get; private set; }

        public GameRoomScreen() : this(null) { }

        public GameRoomScreen(GameRoom _gameRoom)
        {
            if (_gameRoom is null)
            {
                throw new Exception("Can't Open Game Room Screen Without a Valid Game Room.");//not to user!
            }
            GameRoom = _gameRoom;
        }

        public void Run()
        {
            Console.Clear();
            int selection = 0;
            Console.WriteLine("Welcome to the Game Room!");
            Console.WriteLine($"Room Code: { GameRoom.RoomCode }");

            if(GameRoom.NumOfActivePlayers < 2)//at least 2 players to play a game
            {
                Console.WriteLine("Not Enough Players Yet.");
                Console.WriteLine("Ask Some Friends To Join You Using the Code Above.");
                while (GameRoom.NumOfActivePlayers < 2) { }
            }
            Console.WriteLine("Someone Joined My Game");
            Console.ReadLine();
            //while (selection == 0)
            //{
            //    Console.WriteLine("What Would You Like To Do?");
            //    Console.WriteLine("1. Create New Game Room");
            //    Console.WriteLine("2. Join A Game Room");
            //    Console.WriteLine("3. View My Games History");
            //    Console.WriteLine("4. Exit");
            //}
            Console.WriteLine();
        }
    }


}
