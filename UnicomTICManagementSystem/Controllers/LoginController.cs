using System;
using System.Data.SQLite;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Enums;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    public class LoginController
    {
        public LoginModel AuthenticateUser(string username, string password)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE UserName = @username AND UserPass = @password";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var userId = Convert.ToInt32(reader["UserId"]);
                            var roleString = reader["UserRole"].ToString();

                            if (!Enum.TryParse(roleString, true, out UserRole role))
                                return null;

                            string tableName = null;
                            switch (role)
                            {
                                case UserRole.Student:
                                    tableName = "Students";
                                    break;
                                case UserRole.Staff:
                                    tableName = "Staffs";
                                    break;
                                case UserRole.Lecture:
                                    tableName = "Lectures";
                                    break;
                                default:
                                    tableName = null;
                                    break;
                            }

                            string fullName = (tableName != null)
                                ? GetFullName(conn, tableName, userId)
                                : "Admin";

                            return new LoginModel
                            {
                                UserId = userId,
                                UserRole = role,
                                UserName = username,
                                FullName = fullName
                            };
                        }
                    }
                }
            }
            return null;
        }

        private string GetFullName(SQLiteConnection conn, string tableName, int userId)
        {
            string columnName;
            switch (tableName)
            {
                case "Students":
                    columnName = "StdName";
                    break;
                case "Staffs":
                    columnName = "StaffName";
                    break;
                case "Lectures":
                    columnName = "LecName";
                    break;
                default:
                    columnName = "Name";
                    break;
            }

            string query = $"SELECT {columnName} FROM {tableName} WHERE UserId = @userId";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "Unknown";
            }
        }
    }
}
