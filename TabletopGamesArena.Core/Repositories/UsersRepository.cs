using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

using TabletopGamesArena.Core.DBMangement;
using TabletopGamesArena.Core.Modules;

namespace TabletopGamesArena.Core.Repositories
{
    internal class UsersRepository
    {
        /// <summary>
        /// Adds new user to the DB if the username does not exist
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <param name="name"></param>
        /// <returns>if username already exists - returns -1, otherwise returns the new user ID</returns>
        internal static int AddNewUser(string uname, string pwd, string name)
        {
            int userID = 0;
            try
            {
                using (MySqlIO MySql = new MySqlIO())
                {
                    using (MySqlCommand cmd = MySql.CreateCommand())
                    {
                        cmd.CommandText = "AddUser";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@uname", uname);
                        cmd.Parameters["@uname"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@pwd", pwd.ThGetSHA256_hash());
                        cmd.Parameters["@pwd"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@sname", name);
                        cmd.Parameters["@sname"].Direction = ParameterDirection.Input;

                        var res = cmd.ExecuteScalar();
                        userID = res.ThGetInt();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return userID;
        }
        /// <summary>
        /// Gets the userID, password, and screenName by the username
        /// </summary>
        /// <param name="uname"></param>
        /// <returns>User object with the user data</returns>
        internal static User GetUserLoginInfo(string uname)
        {
            User userInfo = new User();
            try
            {
                using (MySqlIO MySql = new MySqlIO())
                {
                    using (MySqlCommand cmd = MySql.CreateCommand())
                    {
                        cmd.CommandText = @"select ID, Password, ScreenName 
                                            from Users 
                                            where Username = @uname;";

                        cmd.Parameters.AddWithValue("@uname", uname);

                        MySqlDataReader rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            userInfo.ID = rs["ID"].ThGetInt();
                            userInfo.Password = rs["Password"].ThGetTrimedString();
                            userInfo.ScreenName = rs["ScreenName"].ThGetTrimedString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userInfo;
        }
    }
}
