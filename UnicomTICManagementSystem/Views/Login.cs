using System;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Enums;

namespace UnicomTICManagementSystem
{
    public partial class Login : Form
    {
        private readonly LoginController loginController = new LoginController();

        public Login()
        {
            InitializeComponent();
        }

        private void Sign_Click(object sender, EventArgs e)
        {
            string username = LogName.Text.Trim();
            string password = LogPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            LoginModel user = loginController.AuthenticateUser(username, password);

            if (user != null)
            {
                MessageBox.Show($"Welcome {user.FullName}!\n{user.UserRole}");

                MainMenuForm mainMenu = new MainMenuForm(user.UserId, user.UserRole.ToString());
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            RegistrationForm regis = new RegistrationForm();
            regis.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LogPass.UseSystemPasswordChar = true;
        }
    }
}
