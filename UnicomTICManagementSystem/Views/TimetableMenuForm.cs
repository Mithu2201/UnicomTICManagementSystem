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
    public partial class TimetableMenuForm : Form
    {
        public TimetableMenuForm()
        {
            InitializeComponent();
        }
        public void loadform(object Form)
        {
            if (this.Timepannel.Controls.Count > 0)
                this.Timepannel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Timepannel.Controls.Add(f);
            this.Timepannel.Tag = f;
            f.Show();
        }

        private void ResetAllLabels()
        {
            List<Label> allLabels = new List<Label> { label6, label1, label7, label3, label5 };
            foreach (var label in allLabels)
            {
                label.ForeColor = SystemColors.ControlText;
                label.Font = new Font(label.Font, FontStyle.Regular);
            }
        }
        private void TimetableMenuForm_Load(object sender, EventArgs e)
        {
            ResetAllLabels();
            label1.ForeColor = Color.Blue;
            label1.Font = new Font(label1.Font, FontStyle.Underline);

            loadform(new AddRoomForm());
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label6.ForeColor = Color.Blue;
            label6.Font = new Font(label6.Font, FontStyle.Underline);

            loadform(new AddTimeForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label1.ForeColor = Color.Blue;
            label1.Font = new Font(label1.Font, FontStyle.Underline);

            loadform(new AddRoomForm());
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            ResetAllLabels();
            label3.ForeColor = Color.Blue;
            label3.Font = new Font(label3.Font, FontStyle.Underline);

            loadform(new RoomForm());
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ResetAllLabels();
            label7.ForeColor = Color.Blue;
            label7.Font = new Font(label7.Font, FontStyle.Underline);

            loadform(new TimeTablesForm());
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
