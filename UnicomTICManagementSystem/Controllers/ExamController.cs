using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class ExamController
    {
        public void AddExam(Exam ex)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO Exams (ExamName, ExamMode, SubjectID) VALUES (@ExamName, @ExamMode, @SubjectID)", conn);
                command.Parameters.AddWithValue("@ExamName", ex.Exname);
                command.Parameters.AddWithValue("@ExamMode", ex.Exmode);
                command.Parameters.AddWithValue("@SubjectID", ex.SubID);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateExam(Exam ex)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var command = new SQLiteCommand("UPDATE Exams SET ExamName = @ExamName, ExamMode = @ExamMode, SubjectID = @SubjectID WHERE ExamId = @ExamId", conn);
                command.Parameters.AddWithValue("@ExamId", ex.ExID);
                command.Parameters.AddWithValue("@ExamName", ex.Exname);
                command.Parameters.AddWithValue("@ExamMode", ex.Exmode);
                command.Parameters.AddWithValue("@SubjectID", ex.SubID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteExam(int examId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM Exams WHERE ExamId = @ExamId", conn);
                command.Parameters.AddWithValue("@ExamId", examId);
                command.ExecuteNonQuery();
            }
        }

        public Exam SearchExamBySubjectName(string subjectName)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
            SELECT e.ExamId, e.ExamName, e.ExamMode, e.SubjectID, s.SubjectName
            FROM Exams e
            JOIN Subjects s ON e.SubjectID = s.SubjectId
            WHERE s.SubjectName LIKE @SubName
            LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubName", $"%{subjectName}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Exam
                            {
                                ExID = Convert.ToInt32(reader["ExamId"]),
                                Exname = reader["ExamName"].ToString(),
                                Exmode = reader["ExamMode"].ToString(),
                                SubID = Convert.ToInt32(reader["SubjectID"]),
                                Subname = reader["SubjectName"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }


        public Exam GetExamById(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Exams WHERE ExamId = @ExamId", conn);
                cmd.Parameters.AddWithValue("@ExamId", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Exam
                        {
                            ExID = reader.GetInt32(0),
                            Exname = reader.GetString(1),
                            Exmode = reader.GetString(2),
                            SubID = reader.GetInt32(3)
                        };
                    }
                }
            }

            return null;
        }

        public List<Exam> GetAllExams()
        {
            var exams = new List<Exam>();

            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                SELECT e.ExamId, e.ExamName, e.ExamMode, e.SubjectID, s.SubjectName 
                FROM Exams e
                LEFT JOIN Subjects s ON e.SubjectID = s.SubjectId", conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    exams.Add(new Exam
                    {
                        ExID = reader.GetInt32(0),
                        Exname = reader.GetString(1),
                        Exmode = reader.GetString(2),
                        SubID = reader.GetInt32(3),
                        Subname = reader.IsDBNull(4) ? "" : reader.GetString(4)
                    });
                }
            }

            return exams;
        }

    }   
}
