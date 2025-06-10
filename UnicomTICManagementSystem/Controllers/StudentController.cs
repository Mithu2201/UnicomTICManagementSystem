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
    internal class StudentController
    {

        public void InsertStudent(string name, string phone, string address, int userId)
        {
            string insertQuery = "INSERT INTO Students (StdName, StdPhone, StdAddress, UserId) VALUES (@StdName, @StdPhone, @StdAddress, @UserId)";
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StdName", name);
                    cmd.Parameters.AddWithValue("@StdPhone", phone);
                    cmd.Parameters.AddWithValue("@StdAddress", address);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(int studentid, string name, string phone, string address, int userId)
        {
            string updateQuery = "UPDATE Students SET StdName = @StdName, StdPhone = @StdPhone, StdAddress = @StdAddress, UserId = @UserId WHERE StdId = @StdId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentid);
                    cmd.Parameters.AddWithValue("@StdName", name);
                    cmd.Parameters.AddWithValue("@StdPhone", phone);
                    cmd.Parameters.AddWithValue("@StdAddress", address);
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

        public void DeleteStudent(int id)
        {
            string deleteQuery = "DELETE FROM Students WHERE StdId = @StdId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", id);
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
