using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCZ
{
    internal class DBMySQLUtils
    {
        public static MySqlConnection
       GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password + "; convert zero datetime=True; Connection Timeout=43200;SSL Mode=None;";

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
