using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopGamesArena.Core;
using TabletopGamesArena.Core.Modules;
using static TabletopGamesArena.Enums;

namespace TabletopGamesArena.Demo
{
    public class ArenaScreen
    {
        private Player CurrentPlayer { get; }

        public ArenaScreen() : this(null) { }
        public ArenaScreen(Player _player)
        {
            if (_player is null)
            {
                throw new Exception("Can't Open Arena Screen Without a Valid Player.");
            }

            CurrentPlayer = _player;
        }

        public void Run()
        {
            Console.Clear();

            try
            {
                int selection = 0;
                string roomCode = string.Empty;

                Console.WriteLine($"Hello { CurrentPlayer.ScreenName },");
                Console.WriteLine("Welcome To The Arena!");
                while (selection == 0)
                {
                    Console.WriteLine("What Would You Like To Do?");
                    Console.WriteLine("1. Create New Game Room");
                    Console.WriteLine("2. Join A Game Room");
                    Console.WriteLine("3. View My Games History");
                    Console.WriteLine("4. Exit");
                    selection = int.Parse(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            {
                                CreateGameRoom();
                            }
                            break;
                        case 2:
                            {
                                Console.WriteLine("Enter The Room Code:");
                                roomCode = Console.ReadLine();
                                GameRoom gameRoom = GamesArena.JoinGameRoom(CurrentPlayer, roomCode);
                                GameRoomScreen gameRoomScreen = new GameRoomScreen(gameRoom);
                            }
                            break;
                        case 3:
                            //GameHistoryScreen(player);
                            break;
                        case 4:
                            return;
                        default:
                            selection = 0;
                            Console.WriteLine("Wrong Input. Let's Try Again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Something Went Wrong. Support Code: 5635");
                Console.WriteLine(ex.Message);
            }
        }
        private void CreateGameRoom()
        {
            try
            {
                int selection = 0;
                GameType chosenGame = GameType.None;
                while (selection == 0)
                {
                    Console.WriteLine("What Game Would You Like To Play?");
                    Console.WriteLine("1. Card War");
                    Console.WriteLine("2. Checkers");
                    Console.WriteLine("3. Chess");
                    Console.WriteLine("4. Taki");
                    Console.WriteLine("5. Back to Home Screen");
                    Console.WriteLine("6. Exit");
                    selection = int.Parse(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            chosenGame = GameType.CardWar;
                            break;
                        case 2:
                            chosenGame = GameType.Checkers;
                            break;
                        case 3:
                            chosenGame = GameType.Chess;
                            break;
                        case 4:
                            chosenGame = GameType.Taki;
                            break;
                        case 5:
                            break;
                        case 6:
                            return;
                        default:
                            selection = 0;
                            Console.WriteLine("Wrong Input. Let's Try Again.");
                            break;
                    }
                }

                GameRoom gameRoom = GamesArena.CreateGameRoom(chosenGame, CurrentPlayer);
                GameRoomScreen gameRoomScreen = new GameRoomScreen(gameRoom);
                gameRoomScreen.Run();

                return;
            }
            catch (Exception)
            {
                throw new Exception("Something Went Wrong. Support Code: 1545");
            }
        }

    }
}
