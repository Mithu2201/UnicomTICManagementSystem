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
    internal class AddStatusController
    {
        public void InsertStatus(string name)
        {
            string insertQuery = "INSERT INTO AddStatus (StatusName) VALUES (@StatusName)";
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@StatusName", name);    
                cmd.ExecuteNonQuery();
                MessageBox.Show("Status inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void UpdateStatus(int id, string name)
        {
            string updateQuery = "UPDATE AddStatus SET StatusName = @StatusName WHERE StatusId = @StatusId";
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@StatusId", id);
                cmd.Parameters.AddWithValue("@StatusName", name);      
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    MessageBox.Show("Status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Status not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteClass(int id)
        {
            string deleteQuery = "DELETE FROM AddStatus WHERE StatusId = @StatusId";

            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(deleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("@StatusId", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Status deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Status not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public List<AddStatus> GetAllStatus()
        {
            var classes = new List<AddStatus>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM AddStatus", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    classes.Add(new AddStatus
                    {
                        AddStatusID = reader.GetInt32(0),
                        AddStatusName = reader.GetString(1)
                    });
                }
            }
            return classes;
        }
    }
}
