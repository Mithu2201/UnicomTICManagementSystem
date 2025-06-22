using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class TimetableController
    {
        public void AddTimetable(Timetable time)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"INSERT INTO TimeTables 
            (TimeDay, TimeSlot, RoomId, CourseID, SubID, LecID) 
            VALUES (@TimeDay, @TimeSlot, @RoomId, @CourseID, @SubID, @LecID)", conn);

                cmd.Parameters.AddWithValue("@TimeDay", time.Tiday);
                cmd.Parameters.AddWithValue("@TimeSlot", time.Tislot);
                cmd.Parameters.AddWithValue("@RoomId", time.RoID);
                cmd.Parameters.AddWithValue("@CourseID", time.CourseID);
                cmd.Parameters.AddWithValue("@SubID", time.SubID);
                cmd.Parameters.AddWithValue("@LecID", time.LecID);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTimetable(Timetable time)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"UPDATE TimeTables SET 
            TimeDay = @TimeDay, TimeSlot = @TimeSlot, 
            RoomId = @RoomId, CourseID = @CourseID, SubID = @SubID, LecID = @LecID 
            WHERE TimeId = @TimeId", conn);

                cmd.Parameters.AddWithValue("@TimeId", time.TiID);
                cmd.Parameters.AddWithValue("@TimeDay", time.Tiday);
                cmd.Parameters.AddWithValue("@TimeSlot", time.Tislot);
                cmd.Parameters.AddWithValue("@RoomId", time.RoID);
                cmd.Parameters.AddWithValue("@CourseID", time.CourseID);
                cmd.Parameters.AddWithValue("@SubID", time.SubID);
                cmd.Parameters.AddWithValue("@LecID", time.LecID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTimetable(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM TimeTables WHERE TimeId = @TimeId", conn);
                cmd.Parameters.AddWithValue("@TimeId", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Timetable SearchTimetableBySubjectName(string subjectName)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
            SELECT t.TimeId, t.TimeDay, t.TimeSlot, 
                   t.RoomId, r.RoomMode,
                   t.CourseID, c.CouName,
                   t.SubID, s.SubjectName,
                   t.LecID, l.LecName
            FROM TimeTables t
            LEFT JOIN Rooms r ON t.RoomId = r.RoomId
            LEFT JOIN Courses c ON t.CourseID = c.CouId
            LEFT JOIN Subjects s ON t.SubID = s.SubjectId
            LEFT JOIN lectures l ON t.LecID = l.LecId
            WHERE s.SubjectName LIKE @SubjectName
            LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubjectName", $"%{subjectName}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Timetable
                            {
                                TiID = Convert.ToInt32(reader["TimeId"]),
                                Tiday = reader["TimeDay"].ToString(),
                                Tislot = reader["TimeSlot"].ToString(),
                                RoID = Convert.ToInt32(reader["RoomId"]),
                                Roname = reader.IsDBNull(reader.GetOrdinal("RoomMode")) ? "" : reader["RoomMode"].ToString(),
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                CourseName = reader.IsDBNull(reader.GetOrdinal("CouName")) ? "" : reader["CouName"].ToString(),
                                SubID = Convert.ToInt32(reader["SubID"]),
                                Subname = reader.IsDBNull(reader.GetOrdinal("SubjectName")) ? "" : reader["SubjectName"].ToString(),
                                LecID = Convert.ToInt32(reader["LecID"]),
                                LecName = reader.IsDBNull(reader.GetOrdinal("LecName")) ? "" : reader["LecName"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Timetable GetTimetableById(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    SELECT TimeId, TimeDay, TimeSlot,
                           RoomId, CourseID, SubID, LecID
                    FROM TimeTables WHERE TimeId = @id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Timetable
                        {
                            TiID = Convert.ToInt32(reader["TimeId"]),
                            Tiday = reader["TimeDay"].ToString(),
                            Tislot = reader["TimeSlot"].ToString(),
                            RoID = Convert.ToInt32(reader["RoomId"]),
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            SubID = Convert.ToInt32(reader["SubID"]),
                            LecID = Convert.ToInt32(reader["LecID"])
                        };
                    }
                }
            }

            return null;
        }

        public List<Timetable> GetAllTimetables()
        {
            var list = new List<Timetable>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
            SELECT t.TimeId, t.TimeDay, t.TimeSlot, 
                   t.RoomId, r.RooomName,
                   t.CourseID, c.CouName,
                   t.SubID, s.SubjectName,
                   t.LecID, l.LecName
            FROM TimeTables t
            LEFT JOIN Rooms r ON t.RoomId = r.RoomId
            LEFT JOIN Courses c ON t.CourseID = c.CouId
            LEFT JOIN Subjects s ON t.SubID = s.SubjectId
            LEFT JOIN lectures l ON t.LecID = l.LecId", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Timetable
                        {
                            TiID = reader.GetInt32(0),
                            Tiday = reader.GetString(1),
                            Tislot = reader.GetString(2),
                            RoID = reader.GetInt32(3),
                            Roname = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            CourseID = reader.GetInt32(5),
                            CourseName = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            SubID = reader.GetInt32(7),
                            Subname = reader.IsDBNull(8) ? "" : reader.GetString(8),
                            LecID = reader.GetInt32(9),
                            LecName = reader.IsDBNull(10) ? "" : reader.GetString(10)
                        });
                    }
                }
            }
            return list;
        }
    }
}
