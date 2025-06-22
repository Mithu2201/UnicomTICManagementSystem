using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomTICManagementSystem
{
    public partial class StudentMenuForm : Form
    {
        private readonly int loggedInUserId;
        private readonly string userRole;
        public StudentMenuForm(int userId, string role)
        {
            InitializeComponent();
            loggedInUserId = userId;
            userRole = role;
        }

        public void loadform(object Form)
        {
            if (this.Studentpanel.Controls.Count > 0)
                this.Studentpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Studentpanel.Controls.Add(f);
            this.Studentpanel.Tag = f;
            f.Show();
        }

        private void ResetAllLabels()
        {
            List<Label> allLabels = new List<Label> { label6, label1, label3, label5 };
            foreach (var label in allLabels)
            {
                label.ForeColor = SystemColors.ControlText;
                label.Font = new Font(label.Font, FontStyle.Regular);
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            
        }
        private void StudentMenuForm_Load(object sender, EventArgs e)
        {
            ResetAllLabels();
            label3.ForeColor = Color.Blue;
            label3.Font = new Font(label3.Font, FontStyle.Underline);

            loadform(new StudentTimetableForm(loggedInUserId, userRole));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label3.ForeColor = Color.Blue;
            label3.Font = new Font(label3.Font, FontStyle.Underline);

            loadform(new StudentTimetableForm(loggedInUserId, userRole));
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            ResetAllLabels();
            label6.ForeColor = Color.Blue;
            label6.Font = new Font(label6.Font, FontStyle.Underline);

            loadform(new StudentMarks(loggedInUserId, userRole));
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label5.ForeColor = Color.Blue;
            label5.Font = new Font(label5.Font, FontStyle.Underline);

            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            ResetAllLabels();
            label1.ForeColor = Color.Blue;
            label1.Font = new Font(label1.Font, FontStyle.Underline);

            loadform(new StudentAttendence(loggedInUserId, userRole));
        }
    }
}
