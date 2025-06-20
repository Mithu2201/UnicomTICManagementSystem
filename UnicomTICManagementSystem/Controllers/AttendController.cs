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

    }


}
