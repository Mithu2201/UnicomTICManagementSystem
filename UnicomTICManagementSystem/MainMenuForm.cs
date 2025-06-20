using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem
{
    public partial class MainMenuForm : Form
    {
        private readonly string userRole;
        private readonly int loggedInUserId;

        public MainMenuForm(int userId, string role)
        {
            InitializeComponent();
            loggedInUserId = userId;
            userRole = role;
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (userRole != "Admin")
            {
                MessageBox.Show("Access denied", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            loadform(new UserMenuForm());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (userRole != "Admin")
            {
                MessageBox.Show("Access denied", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            loadform(new CourseMenuForm());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            loadform(new StudentMenuForm(loggedInUserId, userRole));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (userRole != "Admin" && userRole != "Lecture")
            {
                MessageBox.Show("Access denied", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            loadform(new ExamMenuForm());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (userRole != "Admin" && userRole != "Staff")
            {
                MessageBox.Show("Access denied", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            loadform(new TimetableMenuForm());
        }

        private void button17_Click(object sender, EventArgs e)
        {

            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userRole == "Student")
            {
                MessageBox.Show("Access denied", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            loadform(new AttendenceMenu());
        }
    }
}
