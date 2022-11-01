using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCZ
{
    internal class DBUtils
    {
        public static MySqlConnection GetDBConnection()//параметры строки подключения к БД
        {
            string host = Properties.Settings.Default.host;
            int port = Convert.ToInt16(Properties.Settings.Default.port);
            string database = Properties.Settings.Default.database;
            string username = Properties.Settings.Default.user;
            string password = Properties.Settings.Default.password;

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
