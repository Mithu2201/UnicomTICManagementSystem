using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class StudentMarkController
    {
        public StudentMarkModel GetStudentDetailsByUserId(int userId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
                    SELECT s.StdId, s.StdName, s.StdAddress, s.StdPhone,
                           c.CouName, c.CouId
                    FROM Students s
                    JOIN Marks m ON s.StdId = m.StdId
                    JOIN Courses c ON m.CourseId = c.CouId
                    WHERE s.UserId = @UserId
                    LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StudentMarkModel
                            {
                                StdId = Convert.ToInt32(reader["StdId"]),
                                StdName = reader["StdName"].ToString(),
                                StdAddress = reader["StdAddress"].ToString(),
                                StdPhone = reader["StdPhone"].ToString(),
                                CourseName = reader["CouName"].ToString(),
                                CourseId = Convert.ToInt32(reader["CouId"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public StudentMarkModel GetStudentDetailsByStdId(int stdId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
                    SELECT s.StdName, s.StdAddress, s.StdPhone,
                           c.CouName, c.CouId
                    FROM Students s
                    JOIN Marks m ON s.StdId = m.StdId
                    JOIN Courses c ON m.CourseId = c.CouId
                    WHERE s.StdId = @StdId
                    LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", stdId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StudentMarkModel
                            {
                                StdId = stdId,
                                StdName = reader["StdName"].ToString(),
                                StdAddress = reader["StdAddress"].ToString(),
                                StdPhone = reader["StdPhone"].ToString(),
                                CourseName = reader["CouName"].ToString(),
                                CourseId = Convert.ToInt32(reader["CouId"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<SubjectItem> GetSubjectsByCourseId(int courseId)
        {
            var subjects = new List<SubjectItem>();
            using (var conn = Dbconfig.GetConnection())
            {
                string subjectQuery = "SELECT SubjectId, SubjectName FROM Subjects WHERE CourseId = @CourseId";

                using (var cmd = new SQLiteCommand(subjectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new SubjectItem
                            {
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                SubjectName = reader["SubjectName"].ToString()
                            });
                        }
                    }
                }
            }
            return subjects;
        }

        public DataTable GetMarksByStudentAndSubject(int studentId, int subjectId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
                    SELECT e.ExamName, m.MarkScore, m.MarksGrade
                    FROM Marks m
                    JOIN Exams e ON m.SubjectId = e.SubjectID
                    WHERE m.StdId = @StdId AND m.SubjectId = @SubId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentId);
                    cmd.Parameters.AddWithValue("@SubId", subjectId);

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
