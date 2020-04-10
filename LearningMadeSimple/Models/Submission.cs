using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Submission:Assignment
    {
        public int Submission_id { get; set; }
        public string Submitted { get; set; }
        public string Date_submitted { get; set; }

        public Submission() { }
        public Submission(DB db) { Db = db; }

        public async Task<List<Submission>> GetSubmissionsAsync()
        {
            var submissions = new List<Submission>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectAllSubmissions()";
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var submission = new Submission(Db)
                    {
                        Submission_id = reader.GetInt32(0),
                        Submitted = reader.GetString(1),
                        Date_submitted = reader.GetString(2),
                        Points_Earned = reader.GetInt32(3),
                        Student = new Student(Db)
                        {
                            Student_id = reader.GetInt32(4),
                            First_name = reader.GetString(5),
                            Last_name = reader.GetString(6),
                        },
                        AssignmentName = reader.GetString(7),
                        AssignmentDescripion = reader.GetString(8),
                        Date_due = reader.GetString(9),
                        Type = reader.GetString(10),
                        Assn_points_possible = reader.GetInt32(11)
                    };
                    submissions.Add(submission);
                }
            }

            return submissions;
        }

        public async Task<List<Submission>> GetSubmissionBySectionId(int id)
        {
            var submissions = new List<Submission>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectSectionSubmissionsBySectionId(@id)";
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
                    var submission = new Submission(Db)
                    {
                        Submission_id = reader.GetInt32(0),
                        Submitted = reader.GetString(1),
                        Date_submitted = reader.GetString(2),
                        Points_Earned = reader.GetInt32(3),
                        Student = new Student(Db)
                        {
                            Student_id = reader.GetInt32(4),
                            First_name = reader.GetString(5),
                            Last_name = reader.GetString(6),
                        },
                        AssignmentName = reader.GetString(7),
                        AssignmentDescripion = reader.GetString(8),
                        Date_due = reader.GetString(9),
                        Type = reader.GetString(10),
                        Assn_points_possible = reader.GetInt32(11)
                    };
                    submissions.Add(submission);
                }
            }

            return submissions;
        }

        public async Task<List<Submission>> GetSectionSubmissionByStudentId(int section, int student)
        {
            var submissions = new List<Submission>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectSectionSubmissionsByStudentId(@section,@student)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@section",
                DbType = DbType.Int32,
                Value = section
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@student",
                DbType = DbType.Int32,
                Value = student
            });
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var submission = new Submission(Db)
                    {
                        Submission_id = reader.GetInt32(0),
                        Submitted = reader.GetString(1),
                        Date_submitted = reader.GetString(2),
                        Points_Earned = reader.GetInt32(3),
                        Student = new Student(Db)
                        {
                            Student_id = reader.GetInt32(4),
                            First_name = reader.GetString(5),
                            Last_name = reader.GetString(6),
                        },
                        AssignmentName = reader.GetString(7),
                        AssignmentDescripion = reader.GetString(8),
                        Date_due = reader.GetString(9),
                        Type = reader.GetString(10),
                        Assn_points_possible = reader.GetInt32(11)
                    };
                    submissions.Add(submission);
                }
            }

            return submissions;
        }

        public async Task<List<Submission>> GetSectionSubmissionByAssnTypeId(int section, int type)
        {
            var submissions = new List<Submission>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectSectionSubmissionsByTypeId(@section,@type)";
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
                    var submission = new Submission(Db)
                    {
                        Submission_id = reader.GetInt32(0),
                        Submitted = reader.GetString(1),
                        Date_submitted = reader.GetString(2),
                        Points_Earned = reader.GetInt32(3),
                        Student = new Student(Db)
                        {
                            Student_id = reader.GetInt32(4),
                            First_name = reader.GetString(5),
                            Last_name = reader.GetString(6),
                        },
                        AssignmentName = reader.GetString(7),
                        AssignmentDescripion = reader.GetString(8),
                        Date_due = reader.GetString(9),
                        Type = reader.GetString(10),
                        Assn_points_possible = reader.GetInt32(11)
                    };
                    submissions.Add(submission);
                }
            }

            return submissions;
        }

        public async Task<List<Submission>> GetSectionSubmissionByAssnId(int section, int assn)
        {
            var submissions = new List<Submission>();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL SelectSectionSubmissionsByAssnId(@section,@assn)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@section",
                DbType = DbType.Int32,
                Value = section
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@assn",
                DbType = DbType.Int32,
                Value = assn
            });
            var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var submission = new Submission(Db)
                    {
                        Submission_id = reader.GetInt32(0),
                        Submitted = reader.GetString(1),
                        Date_submitted = reader.GetString(2),
                        Points_Earned = reader.GetInt32(3),
                        Student = new Student(Db)
                        {
                            Student_id = reader.GetInt32(4),
                            First_name = reader.GetString(5),
                            Last_name = reader.GetString(6),
                        },
                        AssignmentName = reader.GetString(7),
                        AssignmentDescripion = reader.GetString(8),
                        Date_due = reader.GetString(9),
                        Type = reader.GetString(10),
                        Assn_points_possible = reader.GetInt32(11)
                    };
                    submissions.Add(submission);
                }
            }

            return submissions;
        }
    }
}
