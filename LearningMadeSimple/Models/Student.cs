﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Student
    {
        internal DB Db { get; set; }
        public int StudentId { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }




        public Student() { }

        internal Student(DB db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Student` (`first_name`, `last_name`) VALUES (@first_name, @last_name);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            StudentId = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `Student` SET `first_name`=@first_name, `last_name`=@last_name WHERE `studentId`=@id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `Student` WHERE `studentId` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<Student> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `Student` WHERE `studentId` = @id;";
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
                        StudentId = reader.GetInt32(0),
                        First_name = reader.GetString(1),
                        Last_name = reader.GetString(2)
                    };
                    students.Add(student);
                }
            }
            return students;
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = StudentId
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@first_name",
                DbType = DbType.String,
                Value = First_name,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@last_name",
                DbType = DbType.String,
                Value = Last_name,
            });
        }
    }
}
