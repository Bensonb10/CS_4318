using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Section
    {
        internal DB Db { get; set; }
        public virtual int SectionId { get; set; }
        public string Name { get; set; }



        public Section() { }

        public Section(DB db)
        {
            Db = db;
        }

        public virtual async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Section` (`Name`) VALUES (@name);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            SectionId = (int)cmd.LastInsertedId;
        }

        public virtual async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `Section` SET `Name` = @name WHERE `section` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public virtual async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `Section` WHERE `sectionId` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<Section> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `Section` WHERE `sectionId` = @id;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Section>> GetAllAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `Section`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        private async Task<List<Section>> ReadAllAsync(DbDataReader reader)
        {
            var sections = new List<Section>();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var section = new Section(Db)
                    {
                        SectionId = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                    sections.Add(section);
                }
            }
            return sections;
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = SectionId
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.String,
                Value = Name,
            });
        }
    }
}
