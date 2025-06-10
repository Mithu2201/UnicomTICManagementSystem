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
        public StudentMenuForm()
        {
            InitializeComponent();
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
        private void label6_Click(object sender, EventArgs e)
        {
            
        }
        private void StudentMenuForm_Load(object sender, EventArgs e)
        {
            loadform(new RegistrationForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loadform(new RegistrationForm());
        }
    }
}
