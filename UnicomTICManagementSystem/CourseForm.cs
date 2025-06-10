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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UnicomTICManagementSystem
{
    public partial class CourseForm : Form
    {
        private int selectedCourseId = -1;
        public CourseForm()
        {
            InitializeComponent();
            this.Load += CourseForm_Load;
            CoursedataGridView.CellClick += CoursedataGridView_CellContentClick;
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void ClearInputFields()
        {
            Coucode.Clear();
            Couname.Clear();
            
        }

        private void CoursedataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && CoursedataGridView.Rows[e.RowIndex].Cells["CouId"].Value != null)
            {
                DataGridViewRow selectedRow = CoursedataGridView.Rows[e.RowIndex];

                selectedCourseId = Convert.ToInt32(selectedRow.Cells["CouId"].Value);
                Coucode.Text = selectedRow.Cells["CouCode"].Value.ToString();
                Couname.Text = selectedRow.Cells["CouName"].Value.ToString();
                

            }
        }

        private void LoadDataIntoGrid()
        {
            string query = "SELECT * FROM Courses";

            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    CoursedataGridView.DataSource = dt;
                }
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchName = Coucode.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    string query = "SELECT * FROM Courses WHERE CouCode = @CouCode LIMIT 1";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CouCode", searchName);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedCourseId = Convert.ToInt32(reader["CouId"]);
                                Coucode.Text = reader["CouCode"].ToString();
                                Couname.Text = reader["CouName"].ToString();
                                
                            }
                            else
                            {
                                MessageBox.Show("Course not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearInputFields();
                                selectedCourseId = -1;
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            Course user_01 = new Course
            {
                CourseCode = Coucode.Text,
                CourseName = Couname.Text,
                

            };
            CourseController insert = new CourseController();
            insert.InsertCourse(user_01.CourseCode, user_01.CourseName);

            LoadDataIntoGrid();
            ClearInputFields();
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedCourseId != -1)
            {
                string updatedCode = Coucode.Text;
                string updatedName = Couname.Text;
                

                CourseController controller = new CourseController();
                controller.UpdateCourse(selectedCourseId, updatedCode, updatedName);

                LoadDataIntoGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a Course from the grid to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (CoursedataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row's Id value (make sure "Id" column exists)
                int selectedId = Convert.ToInt32(CoursedataGridView.SelectedRows[0].Cells["CouId"].Value);

                // Ask for confirmation
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this Course?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    CourseController controller = new CourseController();
                    controller.DeleteCourse(selectedId);

                    // Refresh the grid
                    LoadDataIntoGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a Course to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
