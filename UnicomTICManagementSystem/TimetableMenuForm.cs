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
        private void TimetableMenuForm_Load(object sender, EventArgs e)
        {
            loadform(new TimeTablesForm());
        }

        private void label6_Click(object sender, EventArgs e)
        {
            loadform(new TimeTablesForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loadform(new RoomForm());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            loadform(new ClassForm());
        }
    }
}
