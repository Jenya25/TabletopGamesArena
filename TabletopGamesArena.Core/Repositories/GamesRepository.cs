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
    internal class GamesRepository
    {
        /// <summary>
        /// Get ID and Name of all Games
        /// </summary>
        /// <returns>DataTable with all games details</returns>
        internal static DataTable GetGames()
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlIO MySql = new MySqlIO())
                {
                    using (MySqlCommand cmd = MySql.CreateCommand())
                    {
                        cmd.CommandText = @"select ID, Name from Games;";

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
