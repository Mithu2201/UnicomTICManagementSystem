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
    internal class RoomController
    {
        public void AddRoom(Room room)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Rooms (StudyMode, RooomName, RoomMode, ExamID, ClassId) VALUES (@StudyMode, @RooomName, @RoomMode, @ExamID, @ClassId)", conn);
        cmd.Parameters.AddWithValue("@StudyMode", room.StudyMode);
        cmd.Parameters.AddWithValue("@RooomName", room.Roname);
        cmd.Parameters.AddWithValue("@RoomMode", room.Rotype);
        cmd.Parameters.AddWithValue("@ExamID", (object)room.ExID ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ClassId", (object)room.ClID ?? DBNull.Value);
        cmd.ExecuteNonQuery();
            }
        }

        public void UpdateRoom(Room room)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Rooms SET RooomName = @RooomName, RoomMode = @RoomMode, ExamID = @ExamID WHERE RoomId = @RoomId", conn);
                cmd.Parameters.AddWithValue("@RoomId", room.RoID);
                cmd.Parameters.AddWithValue("@RooomName", room.Roname);
                cmd.Parameters.AddWithValue("@RoomMode", room.Rotype);
                cmd.Parameters.AddWithValue("@ExamID", room.ExID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteRoom(int roomId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Rooms WHERE RoomId = @RoomId", conn);
                cmd.Parameters.AddWithValue("@RoomId", roomId);
                cmd.ExecuteNonQuery();
            }
        }

        public Room SearchRoomByName(string roomName)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT * FROM Rooms WHERE RooomName LIKE @Name LIMIT 1";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", $"%{roomName}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Room
                            {
                                RoID = reader.GetInt32(reader.GetOrdinal("RoomId")),
                                Roname = reader.GetString(reader.GetOrdinal("RooomName")),
                                Rotype = reader.GetString(reader.GetOrdinal("RoomMode")),
                                ExID = reader.IsDBNull(reader.GetOrdinal("ExamID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ExamID")),
                                ClID = reader.IsDBNull(reader.GetOrdinal("ClassId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ClassId"))
                            };
                        }
                    }
                }
            }
            return null;
        }


        public Room GetRoomById(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Rooms WHERE RoomId = @RoomId", conn);
                cmd.Parameters.AddWithValue("@RoomId", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Room
                        {
                            RoID = reader.GetInt32(reader.GetOrdinal("RoomId")),
                            Roname = reader.GetString(reader.GetOrdinal("RooomName")),
                            Rotype = reader.GetString(reader.GetOrdinal("RoomMode")),
                            ExID = reader.IsDBNull(reader.GetOrdinal("ExamID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ExamID")),
                            ClID = reader.IsDBNull(reader.GetOrdinal("ClassId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ClassId")),
                            StudyMode = reader.IsDBNull(reader.GetOrdinal("StudyMode")) ? "" : reader.GetString(reader.GetOrdinal("StudyMode"))
                        };
                    }
                }
            }
            return null;
        }

        public List<Room> GetAllRooms()
        {
            var rooms = new List<Room>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
            SELECT r.RoomId, r.StudyMode, 
                   CASE WHEN r.StudyMode = 'Exam' THEN e.ExamName ELSE c.ClassName END as SessionName,
                   r.RooomName, r.RoomMode
            FROM Rooms r
            LEFT JOIN Exams e ON r.ExamID = e.ExamId
            LEFT JOIN Classes c ON r.ClassId = c.ClassId", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room
                        {
                            RoID = reader.GetInt32(0),
                            StudyMode = reader.GetString(1),
                            SessionName = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Roname = reader.GetString(3),
                            Rotype = reader.GetString(4)
                        });
                    }
                }
            }
            return rooms;
        }
    }
}
