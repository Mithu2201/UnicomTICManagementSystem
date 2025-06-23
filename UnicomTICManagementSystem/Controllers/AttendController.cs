using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace UnicomTICManagementSystem.Controllers
{
    internal class AttendController
    {
        public void AddAttend(Attendence attend)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"INSERT INTO Attendances 
            (Date, StatusId, SubjectId, StdId ) 
            VALUES (@Date, @StatusId, @SubjectId, @StdId )", conn);

                cmd.Parameters.AddWithValue("@Date", attend.Statusday);
                cmd.Parameters.AddWithValue("@StatusId", attend.StatusID);
                cmd.Parameters.AddWithValue("@SubjectId", attend.SubID);
                cmd.Parameters.AddWithValue("@StdId", attend.StudentID);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAttend(Attendence attend)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"UPDATE Attendances SET 
            Date = @Date, StatusId = @StatusId, 
            SubjectId = @SubjectId, StdId = @StdId 
            WHERE AttenId = @AttenId", conn);

                cmd.Parameters.AddWithValue("@AttenId", attend.AttendID);
                cmd.Parameters.AddWithValue("@Date", attend.Statusday);
                cmd.Parameters.AddWithValue("@StatusId", attend.StatusID);
                cmd.Parameters.AddWithValue("@SubjectId", attend.SubID);
                cmd.Parameters.AddWithValue("@StdId", attend.StudentID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAttend(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Attendances WHERE AttenId = @AttenId", conn);
                cmd.Parameters.AddWithValue("@AttenId", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Attendence SearchAttendenceByStudentName(string studentName)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
            SELECT a.AttenId, a.Date, 
                   a.StatusId, s.StatusName,
                   a.SubjectId, sub.SubjectName,
                   a.StdId, stu.StdName
            FROM Attendances a
            LEFT JOIN AddStatus s ON a.StatusId = s.StatusId
            LEFT JOIN Subjects sub ON a.SubjectId = sub.SubjectId
            LEFT JOIN Students stu ON a.StdId = stu.StdId
            WHERE stu.StdName LIKE @StdName
            LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdName", $"%{studentName}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Attendence
                            {
                                AttendID = reader.GetInt32(0),
                                Statusday = reader.GetString(1),
                                StatusID = reader.GetInt32(2),
                                Status = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                SubID = reader.GetInt32(4),
                                Subname = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                StudentID = reader.GetInt32(6),
                                StudentName = reader.IsDBNull(7) ? "" : reader.GetString(7)
                            };
                        }
                    }
                }
            }

            return null;
        }


        public Attendence GetAttendenceById(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
            SELECT t.AttenId, t. Date, 
                   t.StdId, t.SubjectId, t.StatusId
            FROM Attendances t
            WHERE t.AttenId = @id";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Attendence
                            {
                                AttendID = Convert.ToInt32(reader["AttenId"]),
                                Statusday = reader["Date"].ToString(),
                                StudentID = Convert.ToInt32(reader["StdId"]),
                                SubID = Convert.ToInt32(reader["SubjectId"]),
                                StatusID = Convert.ToInt32(reader["StatusId"]),
                                
                            };
                        }
                    }
                }
            }

            return null;
        }

        public List<Attendence> GetAllStatusAll()
        {
            var list = new List<Attendence>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
            SELECT a.AttenId, a.Date, 
                   a.StatusId, s.StatusName,
                   a.SubjectId, sub.SubjectName,
                   a.StdId, stu.StdName
            FROM Attendances a
            LEFT JOIN AddStatus s ON a.StatusId = s.StatusId
            LEFT JOIN Subjects sub ON a.SubjectId = sub.SubjectId
            LEFT JOIN Students stu ON a.StdId = stu.StdId", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Attendence
                        {
                            AttendID = reader.GetInt32(0),
                            Statusday = reader.GetString(1),
                            StatusID = reader.GetInt32(2),
                            Status = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            SubID = reader.GetInt32(4),
                            Subname = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            StudentID = reader.GetInt32(6),
                            StudentName = reader.IsDBNull(7) ? "" : reader.GetString(7)
                        });
                    }
                }
            }
            return list;
        }

        public void RecordLoginAttendance(int studentId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string formattedDate = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

                // Avoid duplicate for the day
                string checkQuery = @"SELECT COUNT(*) FROM Attendances 
                              WHERE StdId = @StdId AND Date = @Date";
                var checkCmd = new SQLiteCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@StdId", studentId);
                checkCmd.Parameters.AddWithValue("@Date", formattedDate);

                long exists = (long)checkCmd.ExecuteScalar();
                if (exists > 0)
                    return; // Already marked

                // ✅ Get subject assigned to the student (via course mapping)
                int subjectId = GetAssignedSubjectIdForStudent(studentId, conn);
                int statusId = GetStatusIdByName("Present", conn);

                if (subjectId > 0 && statusId > 0)
                {
                    var insertCmd = new SQLiteCommand(@"INSERT INTO Attendances (Date, StatusId, SubjectId, StdId)
                                                VALUES (@Date, @StatusId, @SubjectId, @StdId)", conn);
                    insertCmd.Parameters.AddWithValue("@Date", formattedDate);
                    insertCmd.Parameters.AddWithValue("@StatusId", statusId);
                    insertCmd.Parameters.AddWithValue("@SubjectId", subjectId);
                    insertCmd.Parameters.AddWithValue("@StdId", studentId);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        private int GetStatusIdByName(string statusName, SQLiteConnection conn)
        {
            var cmd = new SQLiteCommand("SELECT StatusId FROM AddStatus WHERE StatusName = @name", conn);
            cmd.Parameters.AddWithValue("@name", statusName);
            var result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }

        private int GetDefaultSubjectId(int studentId, SQLiteConnection conn)
        {
            var cmd = new SQLiteCommand("SELECT SubjectId FROM Subjects LIMIT 1", conn);
            var result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }

        private int GetAssignedSubjectIdForStudent(int studentId, SQLiteConnection conn)
        {
            string query = @"
        SELECT sub.SubjectId
        FROM StudentCourses sc
        JOIN Subjects sub ON sc.CourseId = sub.CourseId
        WHERE sc.StudentId = @studentId
        LIMIT 1";

            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@studentId", studentId);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }


    }


}
