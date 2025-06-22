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
    public partial class AttendenceMenu : Form
    {
        public AttendenceMenu()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.Attendpanel.Controls.Count > 0)
                this.Attendpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Attendpanel.Controls.Add(f);
            this.Attendpanel.Tag = f;
            f.Show();
        }

        private void ResetAllLabels()
        {
            List<Label> allLabels = new List<Label> { label1, label2 };
            foreach (var label in allLabels)
            {
                label.ForeColor = SystemColors.ControlText;
                label.Font = new Font(label.Font, FontStyle.Regular);
            }
        }
        private void AttendenceMenu_Load(object sender, EventArgs e)
        {
            ResetAllLabels();
            label1.ForeColor = Color.Blue;
            label1.Font = new Font(label1.Font, FontStyle.Underline);

            loadform(new AddStatusForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label1.ForeColor = Color.Blue;
            label1.Font = new Font(label1.Font, FontStyle.Underline);

            loadform(new AddStatusForm());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label2.ForeColor = Color.Blue;
            label2.Font = new Font(label2.Font, FontStyle.Underline);

            loadform(new AttendenceForm());
        }
    }
}
