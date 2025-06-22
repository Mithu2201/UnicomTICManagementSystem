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
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
                    SELECT Date, 
                           (SELECT SubjectName FROM Subjects WHERE SubjectId = a.SubjectId) AS Subject,
                           (SELECT StatusName FROM AddStatus WHERE StatusId = a.StatusId) AS Status
                    FROM Attendances a
                    WHERE a.StdId = @StdId AND a.SubjectId = @SubId AND a.Date = @Date";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentId);
                    cmd.Parameters.AddWithValue("@SubId", subjectId);
                    cmd.Parameters.AddWithValue("@Date", date);

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
