using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopGamesArena.Core.Repositories;
using static TabletopGamesArena.Core.Modules.GameRoom;

namespace TabletopGamesArena.Core.Modules
{
    public class Player
    {
        public int ID { get; }
        public string ScreenName { get; }
        public GameRoom CurrentGameRoom { get; private set; }
        public Player(int id, string sName)
        {
            ID = id;
            ScreenName = sName;
        }
        /// <summary>
        /// Creates a new game room with the selected gameType
        /// </summary>
        /// <param name="_gameType"></param>
        public void CreateGameRoom(GameType _gameType)
        {
            try
            {
                GameRoom gameRoom = new GameRoom(_gameType, this);
                GamesArena.AddGameRoom(gameRoom);
                GamesHistoryRepository.AddGameHistory(gameRoom.GameID, ID);
                CurrentGameRoom = gameRoom;
            }
            catch (Exception)
            {
                throw new Exception("Something Went Wrong. Support Code: 1223");
            }
        }
        /// <summary>
        /// adds palyer to existing game room using room code
        /// </summary>
        /// <param name="RoomCode"></param>
        public void JoinGameRoom(string RoomCode)
        {
            try
            {
                if (!(CurrentGameRoom is null))
                {
                    ExitGameRoom();
                }
                GameRoom gameRoom = GamesArena.GetGameRoom(RoomCode);
                gameRoom.AddPlayer(this);
                GamesHistoryRepository.AddGameHistory(gameRoom.GameID, ID);
                CurrentGameRoom = gameRoom;
            }
            catch (Exception)
            {
                throw; /*new Exception("Something Went Wrong. Support Code: 1443");*/
            }
        }
        /// <summary>
        /// removes the player from the game room
        /// </summary>
        /// <param name="RoomCode"></param>
        public void ExitGameRoom()
        {
            if (CurrentGameRoom is null)
            {
                throw new Exception("Player is not an active player in any game room");
            }
            CurrentGameRoom.ExitRoom(this);
            CurrentGameRoom = null;
        }
        /// <summary>
        /// gets a datatable of user's games history
        /// </summary>
        /// <returns>DataTable of Game history details</returns>
        public DataTable MyHistory() => GamesHistoryRepository.GetGamesHistory(ID);

        ~Player()
        {
            ExitGameRoom();
        }
    }
}
