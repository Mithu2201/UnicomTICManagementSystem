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
    
    public partial class StudentForm : Form
    {
        private int selectedStudentId = -1;
        public StudentForm()
        {
            InitializeComponent();
            this.Load += StudentForm_Load;
            StdddataGridView.CellClick += StdddataGridView_CellContentClick;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void StdddataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && StdddataGridView.Rows[e.RowIndex].Cells["StdId"].Value != null)
            {
                DataGridViewRow selectedRow = StdddataGridView.Rows[e.RowIndex];

                selectedStudentId = Convert.ToInt32(selectedRow.Cells["StdId"].Value);
                Stddname.Text = selectedRow.Cells["StdName"].Value.ToString();
                StddPhone.Text = selectedRow.Cells["StdPhone"].Value.ToString();
                StddAddress.Text = selectedRow.Cells["StdAddress"].Value.ToString();

            }
        }

        private void ClearInputFields()
        {
            Stddname.Clear();
            StddPhone.Clear();
            StddAddress.Clear();
            
        }

        private void LoadDataIntoGrid()
        {
            string query = "SELECT * FROM Students";

            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StdddataGridView.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedStudentId != -1)
            {
                string updatedName = Stddname.Text;
                string updatedPhone = StddPhone.Text;
                string updatedAddress = StddAddress.Text;

                // Get userId from the currently selected row (or from a hidden field)
                int userId = -1;
                if (StdddataGridView.CurrentRow != null)
                {
                    userId = Convert.ToInt32(StdddataGridView.CurrentRow.Cells["UserId"].Value);
                }

                StudentController controller = new StudentController();
                controller.UpdateStudent(selectedStudentId, updatedName, updatedPhone, updatedAddress, userId);

                LoadDataIntoGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a student from the grid to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (StdddataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row's Id value (make sure "Id" column exists)
                int selectedId = Convert.ToInt32(StdddataGridView.SelectedRows[0].Cells["StdId"].Value);

                // Ask for confirmation
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this student?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    StudentController controller = new StudentController();
                    controller.DeleteStudent(selectedId);

                    // Refresh the grid
                    LoadDataIntoGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchName = Stddname.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    string query = "SELECT * FROM Students WHERE StdName = @StdName LIMIT 1";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StdName", searchName);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedStudentId = Convert.ToInt32(reader["StdId"]);
                                Stddname.Text = reader["StdName"].ToString();
                                StddPhone.Text = reader["StdPhone"].ToString();
                                StddAddress.Text = reader["StdAddress"].ToString();
                                
                            }
                            else
                            {
                                MessageBox.Show("Student not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearInputFields();
                                selectedStudentId = -1;
                            }
                        }
                    }
                }
            }
        }
    }
}
