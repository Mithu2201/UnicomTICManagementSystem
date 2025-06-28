using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class MarkController
    {
        public List<Mark> GetAllMarks()
        {
            var markList = new List<Mark>();

            using (var conn = Dbconfig.GetConnection())
            {
                
                string query = @"
                    SELECT m.MarksId, m.MarkScore, m.MarksGrade, 
                   s.StdId, s.StdName,
                   c.CouId, c.CouName, 
                   sub.SubjectId, sub.SubjectName
                    FROM Marks m
                    JOIN Students s ON m.StdId = s.StdId
                    JOIN Courses c ON m.CourseId = c.CouId
                    JOIN Subjects sub ON m.SubjectId = sub.SubjectId";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        markList.Add(new Mark
                        {
                            MaID = Convert.ToInt32(reader["MarksId"]),
                            Mamark = reader["MarkScore"].ToString(),
                            Magrade = reader["MarksGrade"].ToString(),
                            StdID = Convert.ToInt32(reader["StdId"]),
                            Stdname = reader["StdName"].ToString(),
                            CourseId = Convert.ToInt32(reader["CouId"]),
                            CourseName = reader["CouName"].ToString(),
                            SubjectId = Convert.ToInt32(reader["SubjectId"]),
                            SubjectName = reader["SubjectName"].ToString()
                        });
                    }
                }
            }

            return markList;
        }

        public void AddMark(Mark mark)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                
                string query = @"
            INSERT INTO Marks (MarkScore, MarksGrade, StdId, CourseId, SubjectId)
            VALUES (@MarkScore, @MarksGrade, @StdId, @CourseId, @SubjectId)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MarkScore", mark.Mamark);
                    cmd.Parameters.AddWithValue("@MarksGrade", mark.Magrade);
                    cmd.Parameters.AddWithValue("@StdId", mark.StdID);
                    cmd.Parameters.AddWithValue("@CourseId", mark.CourseId);
                    cmd.Parameters.AddWithValue("@SubjectId", mark.SubjectId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMark(Mark mark)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                
                string query = @"
            UPDATE Marks
            SET MarkScore = @MarkScore,
                MarksGrade = @MarksGrade,
                StdId = @StdId,
                CourseId = @CourseId,
                SubjectId = @SubjectId
            WHERE MarksId = @MarksId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MarkScore", mark.Mamark);
                    cmd.Parameters.AddWithValue("@MarksGrade", mark.Magrade);
                    cmd.Parameters.AddWithValue("@StdId", mark.StdID);
                    cmd.Parameters.AddWithValue("@CourseId", mark.CourseId);
                    cmd.Parameters.AddWithValue("@SubjectId", mark.SubjectId);
                    cmd.Parameters.AddWithValue("@MarksId", mark.MaID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMark(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = "DELETE FROM Marks WHERE MarksId = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Mark> SearchMarksBySubjectName(string subjectName)
        {
            var result = new List<Mark>();
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
            SELECT m.MarksId, m.MarkScore, m.MarksGrade,
                   s.StdId, s.StdName,
                   c.CouId, c.CouName,
                   sub.SubjectId, sub.SubjectName
            FROM Marks m
            JOIN Students s ON m.StdId = s.StdId
            JOIN Courses c ON m.CourseId = c.CouId
            JOIN Subjects sub ON m.SubjectId = sub.SubjectId
            WHERE sub.SubjectName LIKE @subjectName";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@subjectName", $"%{subjectName}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Mark
                            {
                                MaID = Convert.ToInt32(reader["MarksId"]),
                                Mamark = reader["MarkScore"].ToString(),
                                Magrade = reader["MarksGrade"].ToString(),
                                StdID = Convert.ToInt32(reader["StdId"]),
                                Stdname = reader["StdName"].ToString(),
                                CourseId = Convert.ToInt32(reader["CouId"]),
                                CourseName = reader["CouName"].ToString(),
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                SubjectName = reader["SubjectName"].ToString()
                            });
                        }
                    }
                }
            }

            return result;
        }


        public Mark GetMarkById(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                
                string query = @"
            SELECT m.MarksId, m.MarkScore, m.MarksGrade,
                   s.StdId, s.StdName,
                   c.CouId, c.CouName,
                   sub.SubjectId, sub.SubjectName
            FROM Marks m
            JOIN Students s ON m.StdId = s.StdId
            JOIN Courses c ON m.CourseId = c.CouId
            JOIN Subjects sub ON m.SubjectId = sub.SubjectId
            WHERE m.MarksId = @MarksId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MarksId", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Mark
                            {
                                MaID = Convert.ToInt32(reader["MarksId"]),
                                Mamark = reader["MarkScore"].ToString(),
                                Magrade = reader["MarksGrade"].ToString(),
                                StdID = Convert.ToInt32(reader["StdId"]),
                                Stdname = reader["StdName"].ToString(),
                                CourseId = Convert.ToInt32(reader["CouId"]),
                                CourseName = reader["CouName"].ToString(),
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                SubjectName = reader["SubjectName"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public DataTable GetSubjectsByCourse(int courseId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectId, SubjectName FROM Subjects WHERE CourseId = @CourseId", conn);
                cmd.Parameters.AddWithValue("@CourseId", courseId);

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }

        public DataTable GetStudentsByCourse(int courseId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    SELECT s.StdId, s.StdName
                    FROM Students s
                    JOIN StudentCourses sc ON s.StdId = sc.StudentId
                    WHERE sc.CourseId = @CourseId", conn);
                cmd.Parameters.AddWithValue("@CourseId", courseId);

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }

        public DataTable GetAllStudents()
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT StdId, StdName FROM Students", conn);
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }

        public bool IsDuplicateMark(int studentId, int subjectId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Marks 
            WHERE StdId = @StdId AND SubjectId = @SubjectId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentId);
                    cmd.Parameters.AddWithValue("@SubjectId", subjectId);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

    }
}
