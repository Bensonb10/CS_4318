using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Semester
    {
        internal DB Db { get; set; }
        public int Semester_id { get; set; }
        public string SemesterName { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public Semester() { }
        public Semester(DB db) { Db = db; }

        public async Task<List<Semester>> GetSemestersAsync()
        {
            var semesters = new List<Semester>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllSemesters()";
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var semester = new Semester(Db)
                    {
                        Semester_id = reader.GetInt32(0),
                        SemesterName = reader.GetString(1),
                        Start_date = reader.GetString(2),
                        End_date = reader.GetString(3)
                    };
                    semesters.Add(semester);
                }
            }
            return semesters;
        }

        public async Task<List<Semester>> GetCurrentSemesterAsync()
        {
            var semesters = new List<Semester>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectCurrentSemesters()";
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var semester = new Semester(Db)
                    {
                        Semester_id = reader.GetInt32(0),
                        SemesterName = reader.GetString(1),
                        Start_date = reader.GetString(2),
                        End_date = reader.GetString(3)
                    };
                    semesters.Add(semester);
                }
            }
            return semesters;
        }

        public async Task<List<Semester>> GetFutureSemestersAsync(string time)
        {
            var semesters = new List<Semester>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllSemesterAfterStart(@time)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@time",
                DbType = DbType.String,
                Value = time
            });
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var semester = new Semester(Db)
                    {
                        Semester_id = reader.GetInt32(0),
                        SemesterName = reader.GetString(1),
                        Start_date = reader.GetString(2),
                        End_date = reader.GetString(3)
                    };
                    semesters.Add(semester);
                }
            }
            return semesters;
        }
    }
}
