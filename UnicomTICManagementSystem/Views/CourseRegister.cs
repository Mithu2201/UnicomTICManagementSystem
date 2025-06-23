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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UnicomTICManagementSystem.Views
{
    public partial class CourseRegisterForm : Form
    {
        private StudentCourseController controller = new StudentCourseController();
        private int selectedSCId = -1;
        public CourseRegisterForm()
        {
            InitializeComponent();
            LoadStudents();
            LoadCourses();
            LoadStudentCourses();

            studentCourseDataGridView.SelectionChanged += studentCourseDataGridView_SelectionChanged;
        }

        private void CourseRegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadStudents()
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT StdId, StdName FROM Students", conn);
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                studentComboBox.DisplayMember = "StdName";
                studentComboBox.ValueMember = "StdId";
                studentComboBox.DataSource = dt;
            }
        }

        private void LoadCourses()
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT CouId, CouName FROM Courses", conn);
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                courseComboBox.DisplayMember = "CouName";
                courseComboBox.ValueMember = "CouId";
                courseComboBox.DataSource = dt;
            }
        }

        private void LoadStudentCourses()
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                SELECT sc.SCId, s.StdName, c.CouName 
                FROM StudentCourses sc
                JOIN Students s ON sc.StudentId = s.StdId
                JOIN Courses c ON sc.CourseId = c.CouId", conn);

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                studentCourseDataGridView.DataSource = dt;
            }
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (studentComboBox.SelectedValue == null || courseComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select both student and course.");
                return;
            }

            controller.AssignCourseToStudent(new StudentCourse
            {
                StudentId = Convert.ToInt32(studentComboBox.SelectedValue),
                CourseId = Convert.ToInt32(courseComboBox.SelectedValue)
            });

            LoadStudentCourses();
            ClearForm();
            MessageBox.Show("Course Assigned Successfully!");
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedSCId == -1)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            controller.UpdateStudentCourse(new StudentCourse
            {
                SCId = selectedSCId,
                StudentId = Convert.ToInt32(studentComboBox.SelectedValue),
                CourseId = Convert.ToInt32(courseComboBox.SelectedValue)
            });

            LoadStudentCourses();
            ClearForm();
            MessageBox.Show("Assignment Updated Successfully!");
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (selectedSCId == -1)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            controller.DeleteStudentCourse(selectedSCId);
            LoadStudentCourses();
            ClearForm();
            selectedSCId = -1;
            MessageBox.Show("Assignment Deleted Successfully!");
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            if (studentComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a student to search.");
                return;
            }

            int studentId = Convert.ToInt32(studentComboBox.SelectedValue);
            var filteredCourses = controller.GetCoursesByStudentDataTable(studentId);

            if (filteredCourses.Rows.Count == 0)
            {
                MessageBox.Show("No courses found for the selected student.");
                studentCourseDataGridView.DataSource = null;
                ClearForm();
                return;
            }

            studentCourseDataGridView.DataSource = filteredCourses;

            // Select the first row and show it in the ComboBoxes
            if (studentCourseDataGridView.Rows.Count > 0)
            {
                studentCourseDataGridView.Rows[0].Selected = true;

                selectedSCId = Convert.ToInt32(filteredCourses.Rows[0]["SCId"]);

                // Set ComboBoxes using values
                studentComboBox.SelectedValue = studentId;

                string courseName = filteredCourses.Rows[0]["CouName"].ToString();
                foreach (DataRowView course in courseComboBox.Items)
                {
                    if (course["CouName"].ToString() == courseName)
                    {
                        courseComboBox.SelectedValue = course["CouId"];
                        break;
                    }
                }
            }
        }

        private void studentCourseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = studentCourseDataGridView.Rows[e.RowIndex];
                selectedSCId = Convert.ToInt32(row.Cells["SCId"].Value);
                studentComboBox.Text = row.Cells["StdName"].Value.ToString();
                courseComboBox.Text = row.Cells["CouName"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            studentComboBox.SelectedIndex = -1;
            courseComboBox.SelectedIndex = -1;

            selectedSCId = -1;
        }

        private void studentCourseDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (studentCourseDataGridView.SelectedRows.Count > 0)
            {
                var row = studentCourseDataGridView.SelectedRows[0];
                if (row != null)
                {
                    selectedSCId = Convert.ToInt32(row.Cells["SCId"].Value);

                    string selectedStudentName = row.Cells["StdName"].Value.ToString();
                    string selectedCourseName = row.Cells["CouName"].Value.ToString();

                    // Set display text in ComboBoxes based on the selected row
                    studentComboBox.Text = selectedStudentName;
                    courseComboBox.Text = selectedCourseName;
                }
            }
            else
            {
                ClearForm();
            }
        }
    }
}
