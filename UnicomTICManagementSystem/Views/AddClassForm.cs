using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem
{
    public partial class AddClassForm : Form
    {
        private int selectedClassId = -1;
        public AddClassForm()
        {
            InitializeComponent();
            this.Load += AddClassForm_Load;
            CldataGridView.CellClick += CldataGridView_CellContentClick;
        }

        private void AddClassForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            string query = "SELECT * FROM AddClasses";
            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    CldataGridView.DataSource = dt;
                }
            }
        }

        private void ClearInputFields()
        {
            Clcode.Clear();
            Clname.Clear();
            selectedClassId = -1;
        }

        private void CldataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && CldataGridView.Rows[e.RowIndex].Cells["ClId"].Value != null)
            {
                DataGridViewRow selectedRow = CldataGridView.Rows[e.RowIndex];
                selectedClassId = Convert.ToInt32(selectedRow.Cells["ClId"].Value);
                Clname.Text = selectedRow.Cells["ClName"].Value.ToString();
                Clcode.Text = selectedRow.Cells["ClMode"].Value.ToString();
            }
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Clname.Text) || string.IsNullOrEmpty(Clcode.Text))
            {
                MessageBox.Show("Both Class Code and Class Name are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var controller = new AddClassController();
            controller.InsertClass(Clname.Text.Trim(), Clcode.Text.Trim());
            LoadDataIntoGrid();
            ClearInputFields();
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedClassId != -1)
            {
                var controller = new AddClassController();
                controller.UpdateClass(selectedClassId, Clname.Text.Trim(), Clcode.Text.Trim());
                LoadDataIntoGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a Class to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (CldataGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(CldataGridView.SelectedRows[0].Cells["ClId"].Value);
                var result = MessageBox.Show("Are you sure you want to delete this class?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var controller = new AddClassController();
                    controller.DeleteClass(id);
                    LoadDataIntoGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a Class to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchName = Clname.Text.Trim();
            if (!string.IsNullOrEmpty(searchName))
            {
                var controller = new AddClassController();
                var result = controller.SearchClassByName(searchName);

                if (result != null)
                {
                    selectedClassId = result.AddClassID;
                    Clname.Text = result.AddClassName;
                    Clcode.Text = result.AddClassCode;
                }
                else
                {
                    MessageBox.Show("Class not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please enter a class name to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }
    }
}
