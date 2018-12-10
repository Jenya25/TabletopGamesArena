using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopGamesArena.Core.DBMangement;

namespace TabletopGamesArena.Core.Repositories
{
    internal class GamesHistoryRepository
    {
        /// <summary>
        /// Add Record into the games_history table
        /// </summary>
        /// <param name="gameID"></param>
        /// <param name="playerID"></param>
        internal static void AddGameHistory(int gameID, int playerID)
        {
            try
            {
                using (MySqlIO MySql = new MySqlIO())
                {
                    using (MySqlCommand cmd = MySql.CreateCommand())
                    {
                        cmd.CommandText = @"insert into games_history (GameID,PlayerID) Values (@gameId,@playerId);";

                        cmd.Parameters.AddWithValue("@gameId", gameID);

                        cmd.Parameters.AddWithValue("@playerId", playerID);
                        
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get all the records of game history for the player by userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>DataTable of user games history</returns>
        internal static DataTable GetGamesHistory(int userID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlIO MySql = new MySqlIO())
                {
                    using (MySqlCommand cmd = MySql.CreateCommand())
                    {
                        cmd.CommandText = @"select date_Format(Games_History.CreationTime, '%d/%m/%Y %H:%i') as CreationTime, 
                                            Games.Name as GameName from Games_History 
                                            inner join Games on Games.ID = Games_History.GameID
                                            where PlayerID = @userID
                                            order by Games_History.CreationTime desc;";

                        cmd.Parameters.AddWithValue("@userID", userID);

                        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                        {
                            dataAdapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            

            return dt;
        }
    }
}
