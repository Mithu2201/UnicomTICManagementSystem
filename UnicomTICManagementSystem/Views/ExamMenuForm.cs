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
    public partial class ExamMenuForm : Form
    {
        public ExamMenuForm()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.Exampanel.Controls.Count > 0)
                this.Exampanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Exampanel.Controls.Add(f);
            this.Exampanel.Tag = f;
            f.Show();
        }

        private void ResetAllLabels()
        {
            List<Label> allLabels = new List<Label> { label8, label6, label1, label9, label2, label5 };
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

            loadform(new AddExamForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label1.ForeColor = Color.Blue;
            label1.Font = new Font(label1.Font, FontStyle.Underline);

            loadform(new MarksForm());
        }


        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            ResetAllLabels();
            label2.ForeColor = Color.Blue;
            label2.Font = new Font(label2.Font, FontStyle.Underline);

            loadform(new AddClassForm());
        }

        private void ExamMenuForm_Load(object sender, EventArgs e)
        {
            ResetAllLabels();
            label6.ForeColor = Color.Blue;
            label6.Font = new Font(label6.Font, FontStyle.Underline);

            loadform(new AddExamForm());
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label8.ForeColor = Color.Blue;
            label8.Font = new Font(label8.Font, FontStyle.Underline);

            loadform(new ExamForm());
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label9.ForeColor = Color.Blue;
            label9.Font = new Font(label9.Font, FontStyle.Underline);

            loadform(new ClassForm());
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label5.ForeColor = Color.Blue;
            label5.Font = new Font(label5.Font, FontStyle.Underline);

            this.Hide();
        }
    }
}
