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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
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
            loadform(new UserMenuForm());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            loadform(new CourseMenuForm());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            loadform(new StudentMenuForm());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            loadform(new ExamMenuForm());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            loadform(new TimetableMenuForm());
        }
    }
}
