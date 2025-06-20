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
        }

        private void ClearInputFields()
        {
            Rocode.Clear();
            Roname.Clear();
        }

        private void RodataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && RodataGridView.Rows[e.RowIndex].Cells["RoleId"].Value != null)
            {
                DataGridViewRow selectedRow = RodataGridView.Rows[e.RowIndex];
                selectedRoleId = Convert.ToInt32(selectedRow.Cells["RoleId"].Value);
                Rocode.Text = selectedRow.Cells["RoleCode"].Value.ToString();
                Roname.Text = selectedRow.Cells["RoleName"].Value.ToString();
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
                using (var conn = Dbconfig.GetConnection())
                {
                    string query = "SELECT * FROM Roles WHERE RoleCode = @RoleCode LIMIT 1";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleCode", searchCode);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedRoleId = Convert.ToInt32(reader["RoleId"]);
                                Rocode.Text = reader["RoleCode"].ToString();
                                Roname.Text = reader["RoleName"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Role not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearInputFields();
                                selectedRoleId = -1;
                            }
                        }
                    }
                }
            }
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Rocode.Text) || string.IsNullOrEmpty(Roname.Text))
            {
                MessageBox.Show("Both Role Code and Role Name are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Role role = new Role
            {
                RoleCode = Rocode.Text,
                RoleName = Roname.Text
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
                controller.UpdateRole(selectedRoleId, Rocode.Text, Roname.Text);

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
