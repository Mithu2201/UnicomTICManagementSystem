using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class StudentAttendanceController
    {
        public StudentAttendanceModel GetStudentDetailsByUserId(int userId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT StdId, StdName, StdAddress, StdPhone FROM Students WHERE UserId = @UserId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StudentAttendanceModel
                            {
                                StdId = Convert.ToInt32(reader["StdId"]),
                                StdName = reader["StdName"].ToString(),
                                StdAddress = reader["StdAddress"].ToString(),
                                StdPhone = reader["StdPhone"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public StudentAttendanceModel GetStudentDetailsById(int studentId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT StdName, StdAddress, StdPhone FROM Students WHERE StdId = @StdId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StudentAttendanceModel
                            {
                                StdId = studentId,
                                StdName = reader["StdName"].ToString(),
                                StdAddress = reader["StdAddress"].ToString(),
                                StdPhone = reader["StdPhone"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<(int SubjectId, string SubjectName)> GetSubjectsForStudent(int studentId)
        {
            var subjects = new List<(int, string)>();
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
                    SELECT DISTINCT sub.SubjectId, sub.SubjectName
                    FROM Subjects sub
                    JOIN Marks m ON sub.CourseId = m.CourseId
                    WHERE m.StdId = @StdId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add((reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
            }
            return subjects;
        }

        public DataTable GetAttendanceRecords(int studentId, int subjectId, string date)
        {
            var dt = new DataTable();

            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
            SELECT a.Date, s.StatusName, sub.SubjectName
            FROM Attendances a
            JOIN AddStatus s ON a.StatusId = s.StatusId
            JOIN Subjects sub ON a.SubjectId = sub.SubjectId
            WHERE a.StdId = @studentId AND a.SubjectId = @subjectId AND a.Date = @date";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@subjectId", subjectId);
                    cmd.Parameters.AddWithValue("@date", date);

                    dt.Load(cmd.ExecuteReader());
                }
            }

            return dt;
        }
    }
}
