using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Department
    {
        internal DB Db { get; set; }
        public int Department_id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }

        public Department() { }
        public Department(DB db) { Db = db;  }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            var departments = new List<Department>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllDepartments()";
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while(await reader.ReadAsync())
                {
                    var department = new Department(Db)
                    {
                        Department_id = reader.GetInt32(0),
                        DepartmentName = reader.GetString(1),
                        DepartmentDescription = reader.GetString(2)
                    };
                    departments.Add(department);
                }
            }
            return departments;
        }

        public async Task<Department> FindDepartmentByIdAsync(int id)
        {
            var departments = new List<Department>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectDepartmentById(@id)";
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
                    var department = new Department(Db)
                    {
                        Department_id = reader.GetInt32(0),
                        DepartmentName = reader.GetString(1),
                        DepartmentDescription = reader.GetString(2)
                    };
                    departments.Add(department);
                }
            }

            return departments.Count > 0 ? departments[0] : null;
        }
    }
}
