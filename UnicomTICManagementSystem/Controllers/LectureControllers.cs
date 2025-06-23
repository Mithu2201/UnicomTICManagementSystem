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
    internal class LectureControllers
    {
        public void InsertLecture(string name, string phone, string address, int userId)
        {
            string insertQuery = "INSERT INTO Lectures (LecName, LecPhone, LecAddress, UserId) VALUES (@LecName, @LecPhone, @LecAddress, @UserId)";
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@LecName", name);
                    cmd.Parameters.AddWithValue("@LecPhone", phone);
                    cmd.Parameters.AddWithValue("@LecAddress", address);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateLecture(int studentid, string name, string phone, string address, int userId)
        {
            string updateQuery = "UPDATE Lectures SET LecName = @LecName, LecPhone = @LecPhone, LecAddress = @LecAddress, UserId = @UserId WHERE LecId = @LecId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@LecId", studentid);
                    cmd.Parameters.AddWithValue("@LecName", name);
                    cmd.Parameters.AddWithValue("@LecPhone", phone);
                    cmd.Parameters.AddWithValue("@LecAddress", address);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Lecture updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lecture not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void DeleteLecture(int id)
        {
            string deleteQuery = "DELETE FROM Lectures WHERE LecId = @LecId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@lecId", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Lecture deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lecture not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public Lectures SearchLectureByName(string lecName)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT * FROM Lectures WHERE LecName = @LecName LIMIT 1";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LecName", lecName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Lectures
                            {
                                Lec_ID = Convert.ToInt32(reader["LecId"]),
                                Lec_Name = reader["LecName"].ToString(),
                                Lec_Phone = reader["LecPhone"].ToString(),
                                Lec_Address = reader["LecAddress"].ToString(),
                                User_ID = Convert.ToInt32(reader["UserId"])
                            };
                        }
                    }
                }
            }
            return null;
        }

    }
}
