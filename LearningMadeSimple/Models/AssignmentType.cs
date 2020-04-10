using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class AssignmentType:Roster
    {
        public int Assn_type_id { get; set; }
        public string Type { get; set; }
        public int Assn_points_possible { get; set; }

        public AssignmentType() { }
        public AssignmentType(DB db) { Db = db; }

        public async Task<List<AssignmentType>> GetAssignmentTypesAsync()
        {
            var types = new List<AssignmentType>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllAssnType()";
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var type = new AssignmentType(Db)
                    {
                        Assn_type_id = reader.GetInt32(0),
                        Section_id = reader.GetInt32(1),
                        Type = reader.GetString(2),
                        Assn_points_possible = reader.GetInt32(3)
                    };
                    types.Add(type);
                }
            }

            return types;
        }

        public async Task<List<AssignmentType>> GetAssignmentTypeSectionId(int id)
        {
            var types = new List<AssignmentType>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAssnTypeBySectionId(@id)";
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
                    var type = new AssignmentType(Db)
                    {
                        Assn_type_id = reader.GetInt32(0),
                        Section_id = reader.GetInt32(1),
                        Type = reader.GetString(2),
                        Assn_points_possible = reader.GetInt32(3)
                    };
                    types.Add(type);
                }
            }

            return types;
        }

    }
}
