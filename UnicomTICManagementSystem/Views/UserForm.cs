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
    public partial class UserForm : Form
    {
        private int selectedUserId = -1;
        public UserForm()
        {
            InitializeComponent();
            this.Load += UserForm_Load;
            UserdataGridView.CellClick += UserdataGridView_CellContentClick;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void ClearInputFields()
        {
            UserName.Clear();
            UserPass.Clear();
            UserRole.Clear();
        }

        private void UserdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && UserdataGridView.Rows[e.RowIndex].Cells["UserId"].Value != null)
            {
                DataGridViewRow selectedRow = UserdataGridView.Rows[e.RowIndex];

                selectedUserId = Convert.ToInt32(selectedRow.Cells["UserId"].Value);
                UserName.Text = selectedRow.Cells["UserName"].Value.ToString();
                UserPass.Text = selectedRow.Cells["UserPass"].Value.ToString();
                UserRole.Text = selectedRow.Cells["UserRole"].Value.ToString();
                
            }
        }

        private void LoadDataIntoGrid()
        {
            string query = "SELECT * FROM Users";

            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    UserdataGridView.DataSource = dt;
                }
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchName = UserName.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                UserController controller = new UserController();
                User user = controller.SearchUserByName(searchName);

                if (user != null)
                {
                    selectedUserId = user.UserID;
                    UserName.Text = user.UserName;
                    UserPass.Text = user.PassAdd;
                    UserRole.Text = user.Role;
                }
                else
                {
                    MessageBox.Show("User not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    selectedUserId = -1;
                }
            }
            else
            {
                MessageBox.Show("Please enter a username to search.", "Input Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
           
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedUserId != -1)
            {
                string updatedName = UserName.Text;
                string updatedPass = UserPass.Text;
                string updatedRole = UserRole.Text;

                UserController controller = new UserController();
                controller.UpdateUser(selectedUserId, updatedName, updatedPass, updatedRole);

                LoadDataIntoGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a user from the grid to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (UserdataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row's Id value (make sure "Id" column exists)
                int selectedId = Convert.ToInt32(UserdataGridView.SelectedRows[0].Cells["UserId"].Value);

                // Ask for confirmation
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this user?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    UserController controller = new UserController();
                    controller.DeleteUser(selectedId);

                    // Refresh the grid
                    LoadDataIntoGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a User to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
