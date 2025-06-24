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
    internal class AddRoomController
    {
        public void InsertRoom(string code, string name)
        {
            string insertQuery = "INSERT INTO AddRooms (RoName, RoType) VALUES (@RoName, @RoType)";
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RoName", code);
                    cmd.Parameters.AddWithValue("@RoType", name);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void UpdateRoom(int id, string code, string name)
        {
            string updateQuery = "UPDATE AddRooms SET RoName = @RoName, RoType = @RoType WHERE RoId = @RoId";
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RoId", id);
                    cmd.Parameters.AddWithValue("@RoName", code);
                    cmd.Parameters.AddWithValue("@RoType", name);
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                        MessageBox.Show("Room updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Room not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DeleteRoom(int id)
        {
            string deleteQuery = "DELETE FROM AddRooms WHERE RoId = @RoId";
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RoId", id);
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                        MessageBox.Show("Room deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Room not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public AddRooms SearchRoomByName(string roomName)
        {
            string query = "SELECT * FROM AddRooms WHERE RoName = @RoName LIMIT 1";

            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RoName", roomName);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AddRooms
                        {
                            AddRoomID = Convert.ToInt32(reader["RoId"]),
                            AddRoomCode = reader["RoName"].ToString(),
                            AddRoomName = reader["RoType"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        public List<AddRooms> GetRoomNamesAndTypes()
        {
            var roomList = new List<AddRooms>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT RoName, RoType FROM AddRooms", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roomList.Add(new AddRooms
                    {
                        AddRoomCode = reader.GetString(0), 
                        AddRoomName = reader.GetString(1)  
                    });
                }
            }
            return roomList;
        }
    }
}
