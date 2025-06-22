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
using System.Xml.Linq;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem
{
    public partial class AddStatusForm : Form
    {
        private int selectedStatusId = -1;
        public AddStatusForm()
        {
            InitializeComponent();
            this.Load += AddStatusForm_Load;
            StatusdataGridView.CellClick += StatusdataGridView_CellContentClick;
        }

        private void AddStatusForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void StatusdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && StatusdataGridView.Rows[e.RowIndex].Cells["StatusId"].Value != null)
            {
                DataGridViewRow selectedRow = StatusdataGridView.Rows[e.RowIndex];
                selectedStatusId = Convert.ToInt32(selectedRow.Cells["StatusId"].Value);
                Status.Text = selectedRow.Cells["StatusName"].Value.ToString();
                
            }

        }
        private void LoadDataIntoGrid()
        {
            string query = "SELECT * FROM AddStatus";
            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StatusdataGridView.DataSource = dt;
                }
            }
        }

        private void ClearInputFields()
        {
            StatusSea.Clear();
            Status.Clear();
            selectedStatusId = -1;
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Status.Text))
            {
                MessageBox.Show("Please enter a Status.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var controller = new AddStatusController();
            controller.InsertStatus(Status.Text.Trim());
            LoadDataIntoGrid();
            ClearInputFields();
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedStatusId != -1)
            {
                var controller = new AddStatusController();
                controller.UpdateStatus(selectedStatusId, Status.Text.Trim());
                LoadDataIntoGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a Status to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (StatusdataGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(StatusdataGridView.SelectedRows[0].Cells["StatusId"].Value);
                var result = MessageBox.Show("Are you sure you want to delete this Status?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var controller = new AddStatusController();
                    controller.DeleteClass(id);
                    LoadDataIntoGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a Status to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchName = StatusSea.Text.Trim();
            if (!string.IsNullOrEmpty(searchName))
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    string query = "SELECT * FROM AddStatus WHERE StatusName = @StatusName LIMIT 1";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StatusName", searchName);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedStatusId = Convert.ToInt32(reader["StatusId"]);
                                Status.Text = reader["StatusName"].ToString();
                                
                            }
                            else
                            {
                                MessageBox.Show("Status not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearInputFields();  // make sure you have this method defined
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a class name to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
