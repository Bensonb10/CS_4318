using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Degree: Department
    {
        public int Degree_id { get; set; }
        public string DegreeName { get; set; }
        public string DegreeDescription { get; set; }

        public Degree() { }
        public Degree(DB db) { Db = db; }

        public async Task<List<Degree>> GetAllDegreesAsync()
        {
            var degrees = new List<Degree>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllDegrees()";
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var degree = new Degree(Db)
                    {
                        Degree_id = reader.GetInt32(0),
                        Department_id = reader.GetInt32(1),
                        DepartmentName = reader.GetString(2),
                        DepartmentDescription = reader.GetString(3),
                        DegreeName = reader.GetString(4),
                        DegreeDescription = reader.GetString(5)
                    };
                    degrees.Add(degree);
                }
            }
            return degrees;
        }

        public async Task<Degree> FindDegreeByIdAsync(int id)
        {
            var degrees = new List<Degree>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectDegreeById(@id)";
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
                    var degree = new Degree(Db)
                    {
                        Degree_id = reader.GetInt32(0),
                        Department_id = reader.GetInt32(1),
                        DepartmentName = reader.GetString(2),
                        DepartmentDescription = reader.GetString(3),
                        DegreeName = reader.GetString(4),
                        DegreeDescription = reader.GetString(5)
                    };
                    degrees.Add(degree);
                }
            }

            return degrees.Count > 0 ? degrees[0] : null;
        }

        public async Task<List<Degree>> FindDegreeByDepartmentIdAsync(int id)
        {
            var degrees = new List<Degree>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectDegreeByDepartmentId(@id)";
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
                    var degree = new Degree(Db)
                    {
                        Degree_id = reader.GetInt32(0),
                        Department_id = reader.GetInt32(1),
                        DepartmentName = reader.GetString(2),
                        DepartmentDescription = reader.GetString(3),
                        DegreeName = reader.GetString(4),
                        DegreeDescription = reader.GetString(5)
                    };
                    degrees.Add(degree);
                }
            }

            return degrees;
        }
    }
}
