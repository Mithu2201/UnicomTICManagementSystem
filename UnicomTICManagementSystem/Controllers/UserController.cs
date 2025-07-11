﻿using System;
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
    internal class UserController
    {
        public int InsertUser(string name, string pass, string role)
        {
            int insertedUserId = -1;

            using (var conn = Dbconfig.GetConnection())
            {
                
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
                using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@UserName", name);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose another one.", "Duplicate User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return -1;
                    }
                }

                
                string insertQuery = "INSERT INTO Users (UserName, UserPass, UserRole) VALUES (@UserName, @UserPass, @UserRole)";
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", name);
                    cmd.Parameters.AddWithValue("@UserPass", pass);
                    cmd.Parameters.AddWithValue("@UserRole", role);
                    cmd.ExecuteNonQuery();
                }

                using (var getIdCmd = new SQLiteCommand("SELECT last_insert_rowid()", conn))
                {
                    insertedUserId = Convert.ToInt32(getIdCmd.ExecuteScalar());
                }
            }

            return insertedUserId;
        }

        public void DeleteUser(int id)
        {
            string deleteQuery = "DELETE FROM Users WHERE UserId = @UserId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", id);
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

        public void UpdateUser(int userid, string name, string pass, string role)
        {
            string updateQuery = "UPDATE Users SET UserName = @UserName, UserPass = @UserPass, UserRole = @UserRole WHERE UserId = @UserId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userid);
                    cmd.Parameters.AddWithValue("@UserName", name);
                    cmd.Parameters.AddWithValue("@UserPass", pass);
                    cmd.Parameters.AddWithValue("@UserRole", role);

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

        public User SearchUserByName(string userName)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE UserName = @UserName LIMIT 1";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = Convert.ToInt32(reader["UserId"]),
                                UserName = reader["UserName"].ToString(),
                                PassAdd = reader["UserPass"].ToString(),
                                Role = reader["UserRole"].ToString()
                            };
                        }
                    }
                }
            }
            return null; 
        }

    }
}
