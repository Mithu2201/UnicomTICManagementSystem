using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem
{
    public partial class Login : Form
    {
        private readonly string userRole;
        private readonly int loggedInUserId;

        public Login()
        {
            InitializeComponent();
        }
        public Login(int userId, string role)
        {

            InitializeComponent();
            loggedInUserId = userId;
            userRole = role;
        }

        private void Sign_Click(object sender, EventArgs e)
        {
            string username = LogName.Text.Trim();
            string password = LogPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (var conn = Dbconfig.GetConnection())
            {
                
                string userQuery = "SELECT * FROM Users WHERE UserName = @username AND UserPass = @password";
                using (var userCmd = new SQLiteCommand(userQuery, conn))
                {
                    userCmd.Parameters.AddWithValue("@username", username);
                    userCmd.Parameters.AddWithValue("@password", password);

                    using (var reader = userCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["UserId"]);
                            string role = reader["UserRole"].ToString();

                            string fullName = "";

                            if (role == "Student")
                            {
                                fullName = GetNameFromTable(conn, "Students", "StdName", userId);
                            }
                            else if (role == "Staff")
                            {
                                fullName = GetNameFromTable(conn, "Staffs", "StaffName", userId);
                            }
                            else if (role == "Lecture")
                            {
                                fullName = GetNameFromTable(conn, "Lectures", "LecName", userId);
                            }
                            else
                            { fullName = "Admin"; 
                            }
                                

                            MessageBox.Show($"Welcome {fullName}!\n {role}");

                            // Proceed to main menu
                            MainMenuForm mainMenu = new MainMenuForm(userId, role);
                            mainMenu.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
            }
        }

        private string GetNameFromTable(SQLiteConnection conn, string tableName, string nameColumn, int userId)
        {
            string query = $"SELECT {nameColumn} FROM {tableName} WHERE UserId = @userId";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "Unknown";
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            RegistrationForm regis = new RegistrationForm();
            regis.Show();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        
    }
}
    

