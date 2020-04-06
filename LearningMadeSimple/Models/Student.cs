using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Student
    {
        internal DB Db { get; set; }
        public Degree Degree{ get; set; }
        public string Date_admitted { get; set; }
        public int Student_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip_code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public Student() { }

        internal Student(DB db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Student` (`degree_id`, `first_name`, `last_name`, `email`) VALUES (@degree_id, @first_name, @last_name, @email);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Student_id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `Student` SET `first_name`=@first_name, `last_name`=@last_name WHERE `studentId`=@id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `Student` WHERE `studentId` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var students = new List<Student>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllStudents()";
            DbDataReader reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var student = new Student(Db)
                    {
                        Student_id = reader.GetInt32(0),
                        Degree = new Degree
                        {
                            Degree_id = reader.GetInt32(9),
                            DegreeName = reader.GetString(10),
                            Department_id = reader.GetInt32(11),
                            DepartmentName = reader.GetString(12)
                        },
                        First_name = reader.GetString(1),
                        Last_name = reader.GetString(2),
                        Address = reader.GetString(5),
                        City = reader.GetString(6),
                        State = reader.GetString(7),
                        Zip_code = reader.GetInt32(8),
                        Phone = reader.GetString(3),
                        Email = reader.GetString(4)
                    };
                    students.Add(student);
                }
            }
            return students;
        }

        public async Task<Student> FindOneAsync(int id)
        {
            var students = new List<Student>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectStudentById(@id)";
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
                    var student = new Student(Db)
                    {
                        Student_id = reader.GetInt32(0),
                        Degree = new Degree
                        {
                            Degree_id = reader.GetInt32(9),
                            DegreeName = reader.GetString(10),
                            Department_id = reader.GetInt32(11),
                            DepartmentName = reader.GetString(12)
                        },
                        First_name = reader.GetString(1),
                        Last_name = reader.GetString(2),
                        Address = reader.GetString(5),
                        City = reader.GetString(6),
                        State = reader.GetString(7),
                        Zip_code = reader.GetInt32(8),
                        Phone = reader.GetString(3),
                        Email = reader.GetString(4)
                    };
                    students.Add(student);
                }
            }
            return students.Count > 0 ? students[0] : null;
        }    

        public async Task<List<Student>> GetByDegreeId(int id)
        {
            var students = new List<Student>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectStudentByDegreeId(@id)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id
            });
            DbDataReader reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var student = new Student(Db)
                    {
                        Student_id = reader.GetInt32(0),
                        Degree = new Degree
                        {
                            Degree_id = reader.GetInt32(9),
                            DegreeName = reader.GetString(10),
                            Department_id = reader.GetInt32(11),
                            DepartmentName = reader.GetString(12)
                        },
                        First_name = reader.GetString(1),
                        Last_name = reader.GetString(2),
                        Address = reader.GetString(5),
                        City = reader.GetString(6),
                        State = reader.GetString(7),
                        Zip_code = reader.GetInt32(8),
                        Phone = reader.GetString(3),
                        Email = reader.GetString(4)
                    };
                    students.Add(student);
                }
            }
            return students;
        }

        public async Task<Student> LoginStudent(string email)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL loginStudent(@email)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@email",
                DbType = DbType.String,
                Value = email
            });
            var students = new List<Student>();
            var reader = await cmd.ExecuteReaderAsync();
            using (reader)
            {
                while(await reader.ReadAsync())
                {
                    var student = new Student(Db)
                    {
                        Student_id = reader.GetInt32(0),
                        Email = reader.GetString(1),
                        Password = reader.GetString(2)
                    };
                    students.Add(student);
                }
            }
            return students.Count > 0 ? students[0] : null;
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Student_id
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@degree_id",
                DbType = DbType.Int32,
                Value = Degree.Degree_id,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@first_name",
                DbType = DbType.String,
                Value = First_name,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@last_name",
                DbType = DbType.String,
                Value = Last_name,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@email",
                DbType = DbType.String,
                Value = Email,
            });
        }
    }
}
