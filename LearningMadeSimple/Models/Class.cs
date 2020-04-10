using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Class: Department
    {
        public int Class_id { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int Credit_hours { get; set; }
        public Class() { }
        public Class(DB db) { Db = db; }

        public async Task<List<Class>> GetClassesAsync()
        {
            var classes = new List<Class>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllClasses()";
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var _class = new Class()
                    {
                        Class_id = reader.GetInt32(0),
                        ClassName = reader.GetString(1),
                        ClassDescription = reader.GetString(2),
                        Credit_hours = reader.GetInt32(3),
                        Department_id = reader.GetInt32(4),
                        DepartmentName = reader.GetString(5),
                        DepartmentDescription = reader.GetString(6)
                    };
                    classes.Add(_class);
                }
            }
            return classes;
        }

        public async Task<Class> FindClassByIdAsync(int id)
        {
            var classes = new List<Class>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectClassById(@id)";
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
                    var _class = new Class()
                    {
                        Class_id = reader.GetInt32(0),
                        ClassName = reader.GetString(1),
                        ClassDescription = reader.GetString(2),
                        Credit_hours = reader.GetInt32(3),
                        Department_id = reader.GetInt32(4),
                        DepartmentName = reader.GetString(5),
                        DepartmentDescription = reader.GetString(6)
                    };
                    classes.Add(_class);
                }
            }

            return classes.Count > 0 ? classes[0] : null;
        }

        public async Task<List<Class>> FindClassByDepartmentIdAsync(int id)
        {
            var classes = new List<Class>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllClassesByDepartmentId(@id)";
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
                    var _class = new Class()
                    {
                        Class_id = reader.GetInt32(0),
                        ClassName = reader.GetString(1),
                        ClassDescription = reader.GetString(2),
                        Credit_hours = reader.GetInt32(3),
                        Department_id = reader.GetInt32(4),
                        DepartmentName = reader.GetString(5),
                        DepartmentDescription = reader.GetString(6)
                    };
                    classes.Add(_class);
                }
            }
            return classes;
        }
    }
}
