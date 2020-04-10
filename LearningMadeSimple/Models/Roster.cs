using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Roster: Section
    {
        public int Roster_id { get; set; }
        public Student Student { get; set; }
        public float Points_Possible { get; set; }
        public float Points_Earned { get; set; }
        public float Grade { get; set; }
        public string Letter { get; set; }

        public Roster() { }
        public Roster(DB db) { Db = db; }

        public async Task<List<Roster>> GetGradesById(int id)
        {
            var roster = new List<Roster>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectGradeByRosterId(@id)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id
            });
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var enrolled = new Roster(Db)
                    {
                        Roster_id = reader.GetInt32(0),
                        Instructor = new Employee(Db)
                        {
                            Employee_id = reader.GetInt32(1),
                            First_name = reader.GetString(2),
                            Last_name = reader.GetString(3)
                        },
                        Section_id = reader.GetInt32(4),
                        Room = reader.GetString(5),
                        DayOfWeek = reader.GetString(6),
                        Start_time = reader.GetString(7),
                        End_time = reader.GetString(8),
                        Points_Possible = reader.GetFloat(9),
                        Points_Earned = reader.GetFloat(10),
                        Grade = reader.GetFloat(11),
                        Letter = reader.GetString(12),
                        Student = new Student(Db)
                        {
                            Student_id = reader.GetInt32(13),
                            First_name = reader.GetString(14),
                            Last_name = reader.GetString(15)
                        }
                    };
                    roster.Add(enrolled);
                }
            }
            return roster;
        }

        public async Task<List<Roster>> GetGradesByClassId(int id)
        {
            var roster = new List<Roster>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectGradeByClassId(@id)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id
            });
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var enrolled = new Roster(Db)
                    {
                        Roster_id = reader.GetInt32(0),
                        Instructor = new Employee(Db)
                        {
                            Employee_id = reader.GetInt32(1),
                            First_name = reader.GetString(2),
                            Last_name = reader.GetString(3)
                        },
                        Section_id = reader.GetInt32(4),
                        Room = reader.GetString(5),
                        DayOfWeek = reader.GetString(6),
                        Start_time = reader.GetString(7),
                        End_time = reader.GetString(8),
                        Points_Possible = reader.GetFloat(9),
                        Points_Earned = reader.GetFloat(10),
                        Grade = reader.GetFloat(11),
                        Letter = reader.GetString(12)
                    };
                    roster.Add(enrolled);
                }
            }
            return roster;
        }

        public async Task<List<Roster>> GetGradesByStudentIdAsync(int id)
        {
            var roster = new List<Roster>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectGradeByStudentId(@id)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id
            });
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var enrolled = new Roster(Db)
                    {
                        Roster_id = reader.GetInt32(0),
                        Instructor = new Employee(Db)
                        {
                            Employee_id = reader.GetInt32(1),
                            First_name = reader.GetString(2),
                            Last_name = reader.GetString(3)
                        },
                        Section_id = reader.GetInt32(4),
                        Room = reader.GetString(5),
                        DayOfWeek = reader.GetString(6),
                        Start_time = reader.GetString(7),
                        End_time = reader.GetString(8),
                        Points_Possible = reader.GetFloat(9),
                        Points_Earned = reader.GetFloat(10),
                        Grade = reader.GetFloat(11),
                        Letter = reader.GetString(12)
                    };
                    roster.Add(enrolled);
                }
            }
            return roster;
        }

        public async Task<List<Roster>> GetGradesBySectionId(int id)
        {
            var roster = new List<Roster>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectGradeForSectionId(@id)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id
            });
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var enrolled = new Roster(Db)
                    {
                        Roster_id = reader.GetInt32(0),
                        Student = new Student(Db)
                        {
                            Student_id = reader.GetInt32(1),
                            First_name = reader.GetString(2),
                            Last_name = reader.GetString(3)
                        },
                        Section_id = reader.GetInt32(4),
                        Room = reader.GetString(5),
                        DayOfWeek = reader.GetString(6),
                        Start_time = reader.GetString(7),
                        End_time = reader.GetString(8),
                        Points_Possible = reader.GetFloat(9),
                        Points_Earned = reader.GetFloat(10),
                        Grade = reader.GetFloat(11),
                        Letter = reader.GetString(12)
                    };
                    roster.Add(enrolled);
                }
            }
            return roster;
        }
    }
}
