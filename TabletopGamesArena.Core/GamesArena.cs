using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TabletopGamesArena.Core.Modules;
using TabletopGamesArena.Core.Repositories;
using System.Data;
using TabletopGamesArena.Core.Games;

namespace TabletopGamesArena.Core
{
    public static class GamesArena
    {
        internal static Dictionary<string, GameRoom> Arena = new Dictionary<string, GameRoom>();

        #region Public Functions
        public static Player Login(string username, string password)
        {
            try
            {
                User user = UsersRepository.GetUserLoginInfo(username);
                if(user.ID == 0)
                {
                    return null;
                    //throw new Exception("Username Is Incorrect.");
                }
                if (!user.Password.Equals(password.ThGetSHA256_hash())){
                    return null;
                    //throw new Exception("Password Is Incorrect.");
                }

                return new Player(user.ID, user.ScreenName);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Player InsertUser(string username, string password, string screenName)
        {
            try
            {
                int userID = UsersRepository.AddNewUser(username, password, screenName);
                if(userID == -1)//username already exists
                {
                    return null;
                }
                return new Player(userID,screenName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Functions
        internal static GameRoom GetGameRoom(string RoomCode)
        {
            if (Arena.Keys.Contains(RoomCode))
            {
                return Arena[RoomCode];
            }
            else
            {
                throw new Exception($"Game Room With Code '{ RoomCode }' Was Not Found.");
            }
        }
        internal static void AddGameRoom(GameRoom gameRoom)
        {
            if (Arena is null) Arena = new Dictionary<string, GameRoom>();
            Arena.Add(gameRoom.RoomCode, gameRoom);
        }
        internal static void RemoveGameRoom(string RoomCode)
        {
            if (Arena.Keys.Contains(RoomCode))
            {
                GameRoom gr = Arena[RoomCode];
                if(gr.GetNumOfPlayers() > 0)
                {
                    throw new Exception("Can't remove a room with players inside.");
                }
                Arena.Remove(RoomCode);
            }
        }
        #endregion
    }
}
