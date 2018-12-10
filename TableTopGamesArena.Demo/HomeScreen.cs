using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopGamesArena.Core;
using TabletopGamesArena.Core.Modules;

namespace TabletopGamesArena.Demo
{
    public class HomeScreen
    {
        /// <summary>
        /// Runs the Home Screen and redirects to the arena if the user logged in
        /// </summary>
        public void Run()
        {
            Console.Clear();

            int selection = 0;
            Console.WriteLine("Hello, Welcome To Tabletop Games Arena!");
            Player player = new Player();
            try
            {
                while (player.ID == 0)
                {
                    try
                    {
                        Console.WriteLine("What Would You Like To Do?");
                        Console.WriteLine("1. Register");
                        Console.WriteLine("2. Login");
                        Console.WriteLine("3. Exit");
                        selection = int.Parse(Console.ReadLine());

                        switch (selection)
                        {
                            case 1:
                                player = Register();
                                break;
                            case 2:
                                player = Login();
                                break;
                            case 3:
                                return;
                            default:
                                Console.WriteLine("Wrong Input. Let's Try Again.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                ArenaScreen arenaScreen = new ArenaScreen(player);
                arenaScreen.Run();
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong. Support Code: 5545");
            }
        }


        #region Private Functions
        /// <summary>
        /// asks user info from the user and registers a new user
        /// </summary>
        /// <returns>The user ID</returns>
        private static Player Register()
        {
            Player player = new Player();

            Console.WriteLine("Select a Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Insert a Password:");
            string password = GetPasswordFromConsole();
            Console.WriteLine("Select a Screen Name:");
            string screenName = Console.ReadLine();

            try
            {
                player = GamesArena.InsertUser(username, password, screenName);
            }
            catch (Exception)
            {
                throw new Exception("Something Went Wrong. Support Code: 5315");
            }

            if (player.ID == -1)
            {
                throw new Exception("Username already in use.");
            }
            if (player.ID == 0)
            {
                throw new Exception("Something went wrong. Support Code: 5245");
            }
            return player;
        }
        /// <summary>
        /// Asks the username and password from user and tries to log in the user
        /// </summary>
        /// <returns>Player object - with player ID and Player name</returns>
        private static Player Login()
        {
            Player player = new Player();

            Console.WriteLine("What is Your Username?");
            string username = Console.ReadLine();
            Console.WriteLine("What is Your Password?");
            string password = GetPasswordFromConsole();

            try
            {
                player = GamesArena.Login(username, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return player;
        }
        /// <summary>
        /// Hides password string from screen
        /// </summary>
        /// <returns>user's password</returns>
        private static string GetPasswordFromConsole()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        return pass;
                    }
                }
            } while (true);
        }
        #endregion
    }
}
