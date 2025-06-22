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
    public partial class UserMenuForm : Form
    {
        public UserMenuForm()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.Userpanel.Controls.Count > 0)
                this.Userpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Userpanel.Controls.Add(f);
            this.Userpanel.Tag = f;
            f.Show();
        }

        private void ResetAllLabels()
        {
            List<Label> allLabels = new List<Label> { label8, label6, label1, label7, label2, label3, label5 };

            foreach (var label in allLabels)
            {
                label.ForeColor = SystemColors.ControlText;
                label.Font = new Font(label.Font, FontStyle.Regular);
            }
        }
        private void UserMenuForm_Load(object sender, EventArgs e)
        {
            ResetAllLabels();
            label8.ForeColor = Color.Blue;
            label8.Font = new Font(label8.Font, FontStyle.Underline);

            loadform(new RoleForm());
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ResetAllLabels(); // Reset others
            label6.ForeColor = Color.Blue;
            label6.Font = new Font(label6.Font, FontStyle.Underline);

            loadform(new RegistrationForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label1.ForeColor = Color.Blue;
            label1.Font = new Font(label1.Font, FontStyle.Underline);

            loadform(new UserForm());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label2.ForeColor = Color.Blue;
            label2.Font = new Font(label2.Font, FontStyle.Underline);

            loadform(new LectureForm());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label3.ForeColor = Color.Blue;
            label3.Font = new Font(label3.Font, FontStyle.Underline);

            loadform(new StaffForm());
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label7.ForeColor = Color.Blue;
            label7.Font = new Font(label7.Font, FontStyle.Underline);

            loadform(new StudentForm());
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label8.ForeColor = Color.Blue;
            label8.Font = new Font(label8.Font, FontStyle.Underline);

            loadform(new RoleForm());
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label5.ForeColor = Color.Red; // Optional: show red for exit
            label5.Font = new Font(label5.Font, FontStyle.Underline);

            this.Hide();
        }
    }
}
