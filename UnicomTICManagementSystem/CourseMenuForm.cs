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
    public partial class CourseMenuForm : Form
    {
        public CourseMenuForm()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.CoursePannel.Controls.Count > 0)
                this.CoursePannel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.CoursePannel.Controls.Add(f);
            this.CoursePannel.Tag = f;
            f.Show();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            loadform(new ExamForm());
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CourseMenuForm_Load(object sender, EventArgs e)
        {
            loadform(new CourseForm());
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            loadform(new CourseForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loadform(new SubjectForm());
        }

        private void label5_Click(object sender, EventArgs e)
        {
          
            this.Hide();
        }
    }
}
