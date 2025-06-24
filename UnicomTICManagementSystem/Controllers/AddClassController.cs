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
    internal class AddClassController
    {
        public void InsertClass(string name, string code)
        {
            string insertQuery = "INSERT INTO AddClasses (ClName, ClMode) VALUES (@ClName, @ClMode)";
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ClName", name);   
                cmd.Parameters.AddWithValue("@ClMode", code);   
                cmd.ExecuteNonQuery();
                MessageBox.Show("Class inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void UpdateClass(int id, string name, string code)
        {
            string updateQuery = "UPDATE AddClasses SET ClName = @ClName, ClMode = @ClMode WHERE ClId = @ClId";
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ClId", id);
                cmd.Parameters.AddWithValue("@ClName", name);   
                cmd.Parameters.AddWithValue("@ClMode", code);  
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    MessageBox.Show("Class updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Class not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteClass(int id)
        {
            string deleteQuery = "DELETE FROM AddClasses WHERE ClId = @ClId";

            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(deleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ClId", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Class deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Class not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public AddClass SearchClassByName(string className)
        {
            string query = "SELECT * FROM AddClasses WHERE ClName = @ClName LIMIT 1";
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClName", className);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AddClass
                        {
                            AddClassID = Convert.ToInt32(reader["ClId"]),
                            AddClassCode = reader["ClMode"].ToString(),  
                            AddClassName = reader["ClName"].ToString()   
                        };
                    }
                }
            }
            return null;
        }



        public List<AddClass> GetClassNamesAndModes()   
        {
            var classList = new List<AddClass>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT ClName, ClMode FROM AddClasses", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    classList.Add(new AddClass
                    {
                        AddClassCode = reader.GetString(0), 
                        AddClassName = reader.GetString(1)  
                    });
                }
            }
            return classList;
        }
    }
}
