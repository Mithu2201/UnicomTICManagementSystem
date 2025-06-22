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
    internal class RoleController
    {

        public void InsertRole(string code, string name)
        {
            string insertQuery = "INSERT INTO Roles (RoleCode, RoleName) VALUES (@RoleCode, @RoleName)";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleCode", code);
                    cmd.Parameters.AddWithValue("@RoleName", name);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Role inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void DeleteRole(int id)
        {
            string deleteQuery = "DELETE FROM Roles WHERE RoleId = @RoleId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleId", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Role deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Role not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void UpdateRole(int roleId, string code, string name)
        {
            string updateQuery = "UPDATE Roles SET RoleCode = @RoleCode, RoleName = @RoleName WHERE RoleId = @RoleId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleId", roleId);
                    cmd.Parameters.AddWithValue("@RoleCode", code);
                    cmd.Parameters.AddWithValue("@RoleName", name);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Role updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Role not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public Role SearchRoleByCode(string roleCode)
        {
            string query = "SELECT * FROM Roles WHERE RoleCode = @RoleCode LIMIT 1";
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RoleCode", roleCode);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Role
                        {
                            RoleID = Convert.ToInt32(reader["RoleId"]),
                            RoleCode = reader["RoleCode"].ToString(),
                            RoleName = reader["RoleName"].ToString()
                        };
                    }
                }
            }
            return null; // Not found
        }

        public List<Role> GetAllRoles()
        {
            var roles = new List<Role>();

            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Roles", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new Role
                    {
                        RoleID = reader.GetInt32(0),
                        RoleCode = reader.GetString(1),
                        RoleName = reader.GetString(2)
                    });
                }
            }

            return roles;
        }

        public List<string> GetAllRoleNames()
        {
            List<string> roles = new List<string>();

            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT RoleName FROM Roles";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(reader["RoleName"].ToString());
                        }
                    }
                }
            }

            return roles;
        }
    }
}
