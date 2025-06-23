using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Views;

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

        private void ResetAllLabels()
        {
            List<Label> allLabels = new List<Label> { label6, label1, label5 };
            foreach (var label in allLabels)
            {
                label.ForeColor = SystemColors.ControlText;
                label.Font = new Font(label.Font, FontStyle.Regular);
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label6.ForeColor = Color.Blue;
            label6.Font = new Font(label6.Font, FontStyle.Underline);

            loadform(new ExamForm());
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CourseMenuForm_Load(object sender, EventArgs e)
        {
            ResetAllLabels();
            label6.ForeColor = Color.Blue;
            label6.Font = new Font(label6.Font, FontStyle.Underline);

            loadform(new CourseForm());
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            ResetAllLabels();
            label6.ForeColor = Color.Blue;
            label6.Font = new Font(label6.Font, FontStyle.Underline);

            loadform(new CourseForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label1.ForeColor = Color.Blue;
            label1.Font = new Font(label1.Font, FontStyle.Underline);

            loadform(new SubjectForm());
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label5.ForeColor = Color.Blue;
            label5.Font = new Font(label5.Font, FontStyle.Underline);

            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label2.ForeColor = Color.Blue;
            label2.Font = new Font(label2.Font, FontStyle.Underline);

            loadform(new CourseRegisterForm());
        }
    }
}
