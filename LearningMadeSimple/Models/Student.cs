using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Student
    {
        internal DB Db { get; set; }
        public Degree Degree{ get; set; }
        public string Date_admitted { get; set; } = "2020-01-01";
        public int Student_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; } = "TBD";
        public string Address { get; set; } = "TBD";
        public string City { get; set; } = "TBD";
        public string State { get; set; } = "TBD";
        public int Zip_code { get; set; } = 77024;
        public string Phone { get; set; } = "TBD";
        public string Email { get; set; } = "TBD";
        public string Password { get; set; } = "asdf";


        public Student() { }

        internal Student(DB db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            string text = @"INSERT INTO `Student` ";
            text += @"(`degree_id`, `first_name`, `last_name`, `address`, `city`, `state`, `zip_code`, `phone`, `email`, `password`) ";
            text += @"VALUES ";
            text += @"(@degree_id, @first_name, @last_name,  @address, @city, @state, @zip_code, @phone, @email, @password);";

            cmd.CommandText = text;
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Student_id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            string text = @"UPDATE `Student` SET ";
            text += @"`degree_id`= @degree_id, ";
            text += @"`date_admitted`= @date_admitted, ";
            text += @"`first_name`= @first_name, ";
            text += @"`last_name`= @last_name, ";
            text += @"`address`= @address, ";
            text += @"`city`= @city, ";
            text += @"`state`= @state, ";
            text += @"`zip_code`= @zip_code, ";
            text += @"`phone`= @phone, ";
            text += @"`email`= @email, ";
            text += @"`password`= @password, ";
            text += @"WHERE `studentId`= @id;";

            cmd.CommandText = text;
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
                ParameterName = "@date_admitted",
                DbType = DbType.String,
                Value = Date_admitted,
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
                ParameterName = "@address",
                DbType = DbType.String,
                Value = Address,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@city",
                DbType = DbType.String,
                Value = City,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@state",
                DbType = DbType.String,
                Value = State,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@zip_code",
                DbType = DbType.Int32,
                Value = Zip_code,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@phone",
                DbType = DbType.String,
                Value = Phone,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@email",
                DbType = DbType.String,
                Value = Email,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@password",
                DbType = DbType.String,
                Value = Password,
            });
        }
    }
}
