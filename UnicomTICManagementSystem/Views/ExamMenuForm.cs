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
        private void label6_Click(object sender, EventArgs e)
        {
            loadform(new AddExamForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loadform(new MarksForm());
        }


        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            loadform(new AddClassForm());
        }

        private void ExamMenuForm_Load(object sender, EventArgs e)
        {
            loadform(new AddExamForm());
        }

        private void label8_Click(object sender, EventArgs e)
        {
            loadform(new ExamForm());
        }

        private void label9_Click(object sender, EventArgs e)
        {
            loadform(new ClassForm());
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }
    }
}
