using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomTICManagementSystem
{
    public partial class SubjectForm : Form
    {
        private readonly SubjectControllers SubControll;
        private readonly CourseController CourseControll;
        private int selectSubjectId = -1;
        public SubjectForm()
        {
            InitializeComponent();
            SubControll = new SubjectControllers();
            CourseControll = new CourseController();

            SubdataGridView.SelectionChanged += SubdataGridView_SelectionChanged;

            LoadSubject();
            LoadCourses();
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {

        }

        private void StddataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SubdataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (SubdataGridView.SelectedRows.Count > 0)
            {
                var row = SubdataGridView.SelectedRows[0];
                var SubjectView = row.DataBoundItem as Subject;

                if (SubjectView != null)
                {
                    selectSubjectId = SubjectView.SubID;

                    var Subject = SubControll.GetsubjectById(selectSubjectId);
                    if (Subject != null)
                    {
                        SubCode.Text = Subject.SubCode;
                        SubName.Text = Subject.Subname;
                        SubcomboBox.SelectedValue = Subject.CourseID;
                    }
                }
            }
            else
            {
                ClearForm();
                selectSubjectId = -1;
            }
        }

        private void LoadSubject()
        {
            SubdataGridView.DataSource = null;
            SubdataGridView.DataSource = SubControll.GetAllSubject();

            // Hide the SectionId column if it exists
            if (SubdataGridView.Columns.Contains("CourseID"))
            {
                SubdataGridView.Columns["CourseID"].Visible = false;
            }

            SubdataGridView.ClearSelection();
        }

        private void LoadCourses()
        {
            var Courses = CourseControll.GetAllCourse();
            SubcomboBox.DataSource = Courses;
            SubcomboBox.DisplayMember = "CourseName";
            SubcomboBox.ValueMember = "CourseID";
        }

        private void ClearForm()
        {
            SubCode.Clear();
            SubName.Clear();
            SubcomboBox.SelectedIndex = -1;
            selectSubjectId = -1;
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SubName.Text) || string.IsNullOrWhiteSpace(SubCode.Text))
            {
                MessageBox.Show("Please enter both Name and Code.");
                return;
            }

            if (SubcomboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a Course.");
                return;
            }

            var Subject01 = new Subject
            {
                
                SubCode = SubCode.Text,
                Subname = SubName.Text,
                CourseID = (int)SubcomboBox.SelectedValue
            };

            SubControll.AddSubject(Subject01);
            LoadSubject();
            ClearForm();
            MessageBox.Show("Subject Added Successfully");
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectSubjectId == -1)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(SubCode.Text) || string.IsNullOrWhiteSpace(SubName.Text))
            {
                MessageBox.Show("Please enter both Value.");
                return;
            }

            var Subject01 = new Subject
            {
                SubID = selectSubjectId,
                SubCode = SubCode.Text,
                Subname = SubName.Text,
                CourseID = (int)SubcomboBox.SelectedValue
            };

            SubControll.UpdateSubject(Subject01);
            LoadSubject();
            ClearForm();
            MessageBox.Show("Subject Updated Successfully");
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (selectSubjectId == -1)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this subject?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SubControll.DeleteSubject(selectSubjectId);
                LoadSubject();
                ClearForm();
                MessageBox.Show("Student Deleted Successfully");

            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchName = SubName.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    string query = @"
                SELECT * FROM Subjects 
                WHERE SubjectName LIKE @Name
                LIMIT 1";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", $"%{searchName}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectSubjectId = Convert.ToInt32(reader["SubjectId"]);
                                SubCode.Text = reader["SubjectCode"].ToString();
                                SubName.Text = reader["SubjectName"].ToString();
                                int courseId = Convert.ToInt32(reader["CourseId"]);

                                // Set the dropdown to match the CourseID
                                SubcomboBox.SelectedValue = courseId;
                            }
                            else
                            {
                                MessageBox.Show("Subject not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearForm();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a subject name to search.");
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SubCode.Clear();
            SubName.Clear();
            SubcomboBox.SelectedIndex = -1;
            selectSubjectId = -1;
        }
    }
}
