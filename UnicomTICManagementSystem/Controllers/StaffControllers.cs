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
    internal class StaffControllers
    {

        public void InsertStaff(string name, string phone, string address, int userId)
        {
            string insertQuery = "INSERT INTO Staffs (StaffName, StaffPhone, StaffAddress, UserId) VALUES (@StaffName, @StaffPhone, @StaffAddress, @UserId)";
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffName", name);
                    cmd.Parameters.AddWithValue("@StaffPhone", phone);
                    cmd.Parameters.AddWithValue("@StaffAddress", address);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStaff(int studentid, string name, string phone, string address, int userId)
        {
            string updateQuery = "UPDATE Staffs SET StaffName = @StaffName, StaffPhone = @StaffPhone, StaffAddress = @StaffAddress, UserId = @UserId WHERE StaffId = @StaffId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", studentid);
                    cmd.Parameters.AddWithValue("@StaffName", name);
                    cmd.Parameters.AddWithValue("@StaffPhone", phone);
                    cmd.Parameters.AddWithValue("@StaffAddress", address);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void DeleteStaff(int id)
        {
            string deleteQuery = "DELETE FROM Staff WHERE StaffId = @StaffId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Student not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
