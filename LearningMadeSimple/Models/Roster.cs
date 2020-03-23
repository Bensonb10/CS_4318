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
        public int RosterId { get; set; }
        public int StudentId { get; set;  }

        public Roster() { }
        public Roster(DB db)
        {
            Db = db;
        }

        public override async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Roster` (`studentId`, `sectionId`) VALUES (@studentId, @sectionId);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            RosterId = (int)cmd.LastInsertedId;
        }

        public override async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `Roster` SET `studentId` = @studentId, `sectionId` = @sectionId WHERE `rosterId` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public override async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `Roster` WHERE `rosterId` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public new async Task<Roster> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `Roster` WHERE `rosterId` = @id;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public new async Task<List<Roster>> GetAllAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT Roster.rosterId, Roster.studentId, Section.sectionId, Section.sectionName FROM `Roster` INNER JOIN `Section` ON Roster.sectionId = Section.sectionId;";
            //cmd.CommandText = "selectRosterByStudentId";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@studentId", 1);

            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        private async Task<List<Roster>> ReadAllAsync(DbDataReader reader)
        {
            var rosters = new List<Roster>();

            using (reader)
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    System.Diagnostics.Debug.Write(i + ": " +  reader.GetName(i) + " ");
                }
                System.Diagnostics.Debug.Write("\n");

                while (await reader.ReadAsync())
                {
                    
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        System.Diagnostics.Debug.Write(reader.GetString(i) + " ");
                    }
                    System.Diagnostics.Debug.Write("\n");

                    var roster = new Roster(Db)
                    {
                        RosterId = reader.GetInt32(0),
                        StudentId = reader.GetInt32(1),
                        SectionId = reader.GetInt32(2),
                        Name = reader.GetString(3)
                    };
                    rosters.Add(roster);
                }
            }
            return rosters;
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = RosterId
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@sectionId",
                DbType = DbType.Int32,
                Value = SectionId,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@studentId",
                DbType = DbType.Int32,
                Value = StudentId,
            });
        }
    }
}
