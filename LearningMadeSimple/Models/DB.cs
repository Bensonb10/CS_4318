using System;
using MySql.Data.MySqlClient;

namespace LearningMadeSimple.Models
{
    public class DB
    {
        public MySqlConnection Connection { get;  }

        public DB(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
