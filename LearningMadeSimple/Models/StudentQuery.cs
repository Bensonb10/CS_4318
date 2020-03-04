using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LearningMadeSimple.Models
{
    public class StudentQuery
    {
        public LMS_db Db { get; }

        public StudentQuery(LMS_db db)
        {
            Db = db;
        }

        public async Task<Student> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `Student` WHERE `Id` = @id;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `Student`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        private async Task<List<Student>> ReadAllAsync(DbDataReader reader)
        {
            var students = new List<Student>();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var student = new Student(Db)
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                    students.Add(student);
                }
            }
            return students;
        }
    }
}
