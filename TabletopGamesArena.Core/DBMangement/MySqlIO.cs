using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopGamesArena.Core.DBMangement
{
    internal class MySqlIO : IDisposable
    {
        private string _connString;
        private MySqlConnection _conn;

        internal MySqlIO() :this(ConfigurationManager.ConnectionStrings["TabletopArenaConnection"].ConnectionString) {}
        internal MySqlIO(string ConnectionString)
        {
            _conn = new MySqlConnection();
            _connString = ConnectionString;
            _conn.ConnectionString = _connString;
            _conn.Open();
        }

        internal MySqlCommand CreateCommand()
        {
            try
            {
                return _conn.CreateCommand();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    if (_conn != null) _conn.Dispose();
                    _conn = null;
                }
                catch { }
            }
            GC.SuppressFinalize(this);
        }

        ~MySqlIO()
        {
            Dispose(false);
        }
    }
}
