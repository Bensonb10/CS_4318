using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Threading.Tasks;
using System;

namespace LearningMadeSimple.Models
{
    public class Section: Class
    {
        public int Section_id { get; set; }
        public Employee Instructor { get; set; }
        public Semester Semester { get; set; }
        public string Room { get; set; }
        public string DayOfWeek { get; set; }
        public string Start_time { get; set; }
        public string End_time { get; set; }
        public Section() { }
        public Section(DB db) { Db = db; }

        public async Task<List<Section>> GetSectionsAsync()
        {
            var sections = new List<Section>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllSections()";
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var section = new Section(Db)
                    {
                        Section_id = reader.GetInt32(0),
                        Class_id = reader.GetInt32(1),
                        Instructor = new Employee
                        {
                            Employee_id = reader.GetInt32(2),
                            First_name = reader.GetString(11),
                            Last_name = reader.GetString(12)
                        },
                        Room = reader.GetString(3),
                        DayOfWeek = reader.GetString(4),
                        Start_time = reader.GetString(5),
                        End_time = reader.GetString(6),
                        ClassName = reader.GetString(7),
                        ClassDescription = reader.GetString(8),
                        Credit_hours = reader.GetInt32(9),
                        Department_id = reader.GetInt32(10),
                        Semester = new Semester
                        {
                            Semester_id = reader.GetInt32(13),
                            SemesterName = reader.GetString(14),
                            Start_date = reader.GetString(15),
                            End_date = reader.GetString(16)
                        }

                    };
                    sections.Add(section);
                }
            }

            return sections;
        }

        public async Task<List<Section>> GetSectionsByIdAsync(int id)
        {
            var sections = new List<Section>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectSectionById(@id)";
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
                    var section = new Section(Db)
                    {
                        Section_id = reader.GetInt32(0),
                        Class_id = reader.GetInt32(1),
                        Instructor = new Employee
                        {
                            Employee_id = reader.GetInt32(2),
                            First_name = reader.GetString(11),
                            Last_name = reader.GetString(12)
                        },
                        Room = reader.GetString(3),
                        DayOfWeek = reader.GetString(4),
                        Start_time = reader.GetString(5),
                        End_time = reader.GetString(6),
                        ClassName = reader.GetString(7),
                        ClassDescription = reader.GetString(8),
                        Credit_hours = reader.GetInt32(9),
                        Department_id = reader.GetInt32(10),
                        Semester = new Semester
                        {
                            Semester_id = reader.GetInt32(13),
                            SemesterName = reader.GetString(14),
                            Start_date = reader.GetString(15),
                            End_date = reader.GetString(16)
                        }

                    };
                    sections.Add(section);
                }
            }
            return sections;
        }

        public async Task<List<Section>> GetSectionsByClassIdAsync(int id)
        {
            var sections = new List<Section>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectSectionByClassId(@id)";
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
                    var section = new Section(Db)
                    {
                        Section_id = reader.GetInt32(0),
                        Class_id = reader.GetInt32(1),
                        Instructor = new Employee
                        {
                            Employee_id = reader.GetInt32(2),
                            First_name = reader.GetString(11),
                            Last_name = reader.GetString(12)
                        },
                        Room = reader.GetString(3),
                        DayOfWeek = reader.GetString(4),
                        Start_time = reader.GetString(5),
                        End_time = reader.GetString(6),
                        ClassName = reader.GetString(7),
                        ClassDescription = reader.GetString(8),
                        Credit_hours = reader.GetInt32(9),
                        Department_id = reader.GetInt32(10),
                        Semester = new Semester
                        {
                            Semester_id = reader.GetInt32(13),
                            SemesterName = reader.GetString(14),
                            Start_date = reader.GetString(15),
                            End_date = reader.GetString(16)
                        }

                    };
                    sections.Add(section);
                }
            }
            return sections;
        }
    }
}
