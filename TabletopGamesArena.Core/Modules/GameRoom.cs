using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopGamesArena.Core.Games;

namespace TabletopGamesArena.Core.Modules
{
    public class GameRoom
    {
        public enum GameType
        {
            None,
            CardWar,
            Checkers,
            Chess,
            Taki
        }

        public string RoomCode { get; }
        public bool RoomIsClosed { get; private set; }

        public int GameID => ChosenGame.ID;

        private Game ChosenGame { get; }


        public GameRoom(GameType _chosenGame, Player _creator)
        {
            if (_chosenGame == GameType.None || _creator is null)
            {
                throw new Exception("Something Went Wrong. Support Code: 9584");
            }

            RoomCode = GetNewRoomCode();

            switch (_chosenGame)
            {
                case GameType.CardWar:
                    ChosenGame = new CardWar();
                    break;
                case GameType.Checkers:
                    ChosenGame = new Checkers();
                    break;
                case GameType.Chess:
                    ChosenGame = new Chess();
                    break;
                case GameType.Taki:
                    ChosenGame = new Taki();
                    break;
                default:
                    throw new Exception("Unknown Type of Game.");
            }

            ChosenGame.AddPlayer(_creator);
        }
        public bool GameCanStart() => ChosenGame.GameCanStart();
        private bool RoomIsFull() => ChosenGame.RoomIsFull();
        public int GetNumOfPlayers() => ChosenGame.GetNumOfActivePlayers();
        private Player PickARandomWinner() => ChosenGame.RandomWinner();
        public void AddPlayer(Player player)
        {
            if(!RoomIsFull() && !RoomIsClosed)
            {
                ChosenGame.AddPlayer(player);
            }
        }
        public Player StartGame()
        {
            RoomIsClosed = true; return ChosenGame.RandomWinner();
        }
        public void ExitRoom(Player player)
        {
            ChosenGame.RemovePlayer(player);
            if(ChosenGame.GetNumOfActivePlayers() == 0)
            {
                GamesArena.RemoveGameRoom(RoomCode);
            }
        }
        private static string GetNewRoomCode()
        {
            return Guid.NewGuid().ToString()
                .Replace("-", string.Empty).Replace("+", string.Empty)
                .Substring(0, 5);
        }

    }
}
