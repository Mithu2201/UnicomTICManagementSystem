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
        private void AttendenceMenu_Load(object sender, EventArgs e)
        {
            loadform(new AddStatusForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loadform(new AddStatusForm());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            loadform(new AttendenceForm());
        }
    }
}
