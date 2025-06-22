using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class StudentTimeTableController
    {
        public List<StudentTimeTable> GetTimeTableBySubjectId(int subjectId)
        {
            var list = new List<StudentTimeTable>();
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
                SELECT tt.TimeDay, tt.TimeSlot, r.RooomName
                FROM TimeTables tt
                JOIN Rooms r ON tt.RoomId = r.RoomId
                WHERE tt.SubID = @SubId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubId", subjectId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new StudentTimeTable
                            {
                                TimeDay = reader["TimeDay"].ToString(),
                                TimeSlot = reader["TimeSlot"].ToString(),
                                RoomName = reader["RooomName"].ToString()
                            });
                        }
                    }
                }
            }

            return list;
        }

        public List<Tuple<int, string>> GetSubjectsForCourse(int courseId)
        {
            var subjectList = new List<Tuple<int, string>>();
            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT SubjectId, SubjectName FROM Subjects WHERE CourseId = @CourseId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjectList.Add(Tuple.Create(reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
            }

            return subjectList;
        }

        public (int courseId, string stdName, string phone, string address, string courseName)? GetStudentDetailsByUserId(int userId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
                SELECT s.StdId, s.StdName, s.StdPhone, s.StdAddress, c.CouId, c.CouName
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
                            return (
                                reader.GetInt32(reader.GetOrdinal("CouId")),
                                reader["StdName"].ToString(),
                                reader["StdPhone"].ToString(),
                                reader["StdAddress"].ToString(),
                                reader["CouName"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }

        public (int courseId, string stdName, string phone, string address, string courseName)? GetStudentDetailsByStudentId(int studentId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
                SELECT s.StdName, s.StdPhone, s.StdAddress, c.CouId, c.CouName
                FROM Students s
                JOIN Marks m ON s.StdId = m.StdId
                JOIN Courses c ON m.CourseId = c.CouId
                WHERE s.StdId = @StdId
                LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                reader.GetInt32(reader.GetOrdinal("CouId")),
                                reader["StdName"].ToString(),
                                reader["StdPhone"].ToString(),
                                reader["StdAddress"].ToString(),
                                reader["CouName"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }
    }
}
