using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Assignment : AssignmentType
    {
        public int Assn_id { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescripion { get; set; }
        public string Date_due { get; set; }

        public Assignment() { }
        public Assignment(DB db) { Db = db; }

        public async Task InsertAssignmentAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            string text = @"INSERT INTO `Assignment` ";
            text += @"(`assn_type_id`, `section_id`, `assignmentName`, `assignmentDescription`, `date_due`) ";
            text += @"VALUES ";
            text += @"(@assn_type_id. @section_id, @assignmentName, @assignmentDescription, @date_due)";

            cmd.CommandText = text;
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Assn_id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAssignmentAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            string text = @"UPDATE `Assignment` SET ";
            text += @"`assn_type_id` = @assn_type_id ";
            text += @"`section_id` = @section_id ";
            text += @"`assignmentName` = @assignmentName ";
            text += @"`assignmentDescription` = @assignmentDescription ";
            text += @"`date_due` = @date_due ";
            text += @"WHERE `assn_id` = @id";

            cmd.CommandText = text;
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAssignmentAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            string text = @"DELETE FROM `Assignment` ";
            text += @"WHERE `assn_id` = @id";

            cmd.CommandText = text;
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            var assignments = new List<Assignment>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllAssignments()";
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {

                    var assignment = new Assignment(Db)
                    {
                        Assn_id = reader.GetInt32(0),
                        Assn_type_id = reader.GetInt32(1),
                        Section_id = reader.GetInt32(2),
                        AssignmentName = reader.GetString(3),
                        AssignmentDescripion = reader.GetString(4),
                        Date_due = reader.GetString(5),
                        Type = reader.GetString(6),
                        Points_Possible = reader.GetInt32(7)
                    };
                    assignments.Add(assignment);
                }
                return assignments;
            }
        }

        public async Task<List<Assignment>> GetAssignmentsSectionId(int id)
        {
            var assignments = new List<Assignment>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllAssignmentBySectionId(@id)";
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

                    var assignment = new Assignment(Db)
                    {
                        Assn_id = reader.GetInt32(0),
                        Assn_type_id = reader.GetInt32(1),
                        Section_id = reader.GetInt32(2),
                        AssignmentName = reader.GetString(3),
                        AssignmentDescripion = reader.GetString(4),
                        Date_due = reader.GetString(5),
                        Type = reader.GetString(6),
                        Points_Possible = reader.GetInt32(7)
                    };
                    assignments.Add(assignment);
                }
                return assignments;
            }
        }

        public async Task<List<Assignment>> GetAssignmentsSectionTypeId(int section, int type)
        {
            var assignments = new List<Assignment>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAssignemntBySectionIdTypeId(@section, @type)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@section",
                DbType = DbType.Int32,
                Value = section
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@type",
                DbType = DbType.Int32,
                Value = type
            });
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {

                    var assignment = new Assignment(Db)
                    {
                        Assn_id = reader.GetInt32(0),
                        Assn_type_id = reader.GetInt32(1),
                        Section_id = reader.GetInt32(2),
                        AssignmentName = reader.GetString(3),
                        AssignmentDescripion = reader.GetString(4),
                        Date_due = reader.GetString(5),
                        Type = reader.GetString(6),
                        Points_Possible = reader.GetInt32(7)
                    };
                    assignments.Add(assignment);
                }
                return assignments;
            }
        }
    
        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Assn_id,
            });
        }
       
        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@assn_id",
                DbType = DbType.Int32,
                Value = Assn_id,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@section_id",
                DbType = DbType.Int32,
                Value = Section_id,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@assignmentName",
                DbType = DbType.String,
                Value = AssignmentName,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@assignmentDescription",
                DbType = DbType.String,
                Value = AssignmentDescripion,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@date_due",
                DbType = DbType.String,
                Value = Date_due,
            });
        }
    }
};
