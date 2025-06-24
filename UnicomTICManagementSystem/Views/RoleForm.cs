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
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem
{
    public partial class RoleForm : Form
    {
        private int selectedRoleId = -1;
        public RoleForm()
        {
            InitializeComponent();
            this.Load += RoleForm_Load;
            RodataGridView.CellClick += RodataGridView_CellContentClick;
        }

        private void RoleForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
            LoadPredefinedRoleNames();  
            
        }

        private void LoadPredefinedRoleNames()
        {
            List<string> predefinedRoles = new List<string>
        {
        "Admin",
        "Student",
        "Staff",
        "Lecture"
        };

            RonamecomboBox.DataSource = predefinedRoles;
        }

        private void ClearInputFields()
        {
            Rocode.Clear();
            RonamecomboBox.SelectedIndex = -1;
        }

        private void RodataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && RodataGridView.Rows[e.RowIndex].Cells["RoleId"].Value != null)
            {
                DataGridViewRow selectedRow = RodataGridView.Rows[e.RowIndex];
                selectedRoleId = Convert.ToInt32(selectedRow.Cells["RoleId"].Value);
                Rocode.Text = selectedRow.Cells["RoleCode"].Value.ToString();
                RonamecomboBox.Text = selectedRow.Cells["RoleName"].Value.ToString();
            }
        }

        private void LoadDataIntoGrid()
        {
            string query = "SELECT * FROM Roles";

            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    RodataGridView.DataSource = dt;
                }
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchCode = Rocode.Text.Trim();

            if (!string.IsNullOrEmpty(searchCode))
            {
                RoleController controller = new RoleController();
                Role role = controller.SearchRoleByCode(searchCode);

                if (role != null)
                {
                    selectedRoleId = role.RoleID;
                    Rocode.Text = role.RoleCode;
                    RonamecomboBox.Text = role.RoleName;
                }
                else
                {
                    MessageBox.Show("Role not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    selectedRoleId = -1;
                }
            }
            else
            {
                MessageBox.Show("Please enter a Role Code to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Rocode.Text) || string.IsNullOrEmpty(RonamecomboBox.Text))
            {
                MessageBox.Show("Both Role Code and Role Name are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = Dbconfig.GetConnection())
            {
                
                string checkQuery = "SELECT COUNT(*) FROM Roles WHERE RoleCode = @RoleCode";
                using (var cmd = new SQLiteCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleCode", Rocode.Text.Trim());
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Role Code already exists. Please enter a unique Role Code.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            Role role = new Role
            {
                RoleCode = Rocode.Text.Trim(),
                RoleName = RonamecomboBox.Text.Trim()
            };

            RoleController controller = new RoleController();
            controller.InsertRole(role.RoleCode, role.RoleName);

            LoadDataIntoGrid();
            ClearInputFields();
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedRoleId != -1)
            {
                RoleController controller = new RoleController();
                controller.UpdateRole(selectedRoleId, Rocode.Text, RonamecomboBox.Text);

                LoadDataIntoGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a Role to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (RodataGridView.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(RodataGridView.SelectedRows[0].Cells["RoleId"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this Role?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    RoleController controller = new RoleController();
                    controller.DeleteRole(selectedId);

                    LoadDataIntoGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a Role to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }
    }
}
