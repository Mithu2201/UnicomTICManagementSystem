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
        private void UserMenuForm_Load(object sender, EventArgs e)
        {
            loadform(new RoleForm());
        }

        private void label6_Click(object sender, EventArgs e)
        {
            loadform(new RegistrationForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loadform(new UserForm());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            loadform(new LectureForm());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            loadform(new StaffForm());
        }

        private void label7_Click(object sender, EventArgs e)
        {
            loadform(new StudentForm());
        }

        private void label8_Click(object sender, EventArgs e)
        {
            loadform(new RoleForm());
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
