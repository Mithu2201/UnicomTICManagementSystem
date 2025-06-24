using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem
{
    public partial class StaffForm : Form
    {
        private int selectedStaffId = -1;
        public StaffForm()
        {
            InitializeComponent();
            this.Load += StaffForm_Load;
            StadataGridView.CellClick += StddataGridView_CellContentClick;
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void StddataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && StadataGridView.Rows[e.RowIndex].Cells["StaffId"].Value != null)
            {
                DataGridViewRow selectedRow = StadataGridView.Rows[e.RowIndex];

                selectedStaffId = Convert.ToInt32(selectedRow.Cells["StaffId"].Value);
                Staname.Text = selectedRow.Cells["StaffName"].Value.ToString();
                StaPhone.Text = selectedRow.Cells["StaffPhone"].Value.ToString();
                StaAddress.Text = selectedRow.Cells["StaffAddress"].Value.ToString();

            }

        }

        private void ClearInputFields()
        {
            Staname.Clear();
            StaPhone.Clear();
            StaAddress.Clear();

        }

        private void LoadDataIntoGrid()
        {
            string query = "SELECT * FROM Staffs";

            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StadataGridView.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedStaffId != -1)
            {
                string updatedName = Staname.Text;
                string updatedPhone = StaPhone.Text;
                string updatedAddress = StaAddress.Text;

                
                int userId = -1;
                if (StadataGridView.CurrentRow != null)
                {
                    userId = Convert.ToInt32(StadataGridView.CurrentRow.Cells["UserId"].Value);
                }

                StaffControllers controller = new StaffControllers();
                controller.UpdateStaff(selectedStaffId, updatedName, updatedPhone, updatedAddress, userId);

                LoadDataIntoGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a staff from the grid to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (StadataGridView.SelectedRows.Count > 0)
            {
                
                int selectedId = Convert.ToInt32(StadataGridView.SelectedRows[0].Cells["StaffId"].Value);

                
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this staff?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    StaffControllers controller = new StaffControllers();
                    controller.DeleteStaff(selectedId);

                    
                    LoadDataIntoGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a staff to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchName = Staname.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                StaffControllers controller = new StaffControllers();
                Staffs staff = controller.SearchStaffByName(searchName);

                if (staff != null)
                {
                    selectedStaffId = staff.Stf_ID;
                    Staname.Text = staff.Stf_Name;
                    StaPhone.Text = staff.Stf_Phone;
                    StaAddress.Text = staff.Stf_Address;
                    
                }
                else
                {
                    MessageBox.Show("Staff not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    selectedStaffId = -1;
                }
            }
            else
            {
                MessageBox.Show("Please enter a staff name to search.", "Input Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
