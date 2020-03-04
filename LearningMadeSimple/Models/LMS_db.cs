using System;
using MySql.Data.MySqlClient;

namespace LearningMadeSimple.Models
{
    public class LMS_db
    {
        public MySqlConnection Connection { get;  }

        public LMS_db(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
