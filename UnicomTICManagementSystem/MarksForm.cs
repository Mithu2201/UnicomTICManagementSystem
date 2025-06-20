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

namespace UnicomTICManagementSystem
{
    public partial class MarksForm : Form
    {
        private MarkController markController = new MarkController();
        private readonly CourseController CourseControll;
        private readonly SubjectControllers subjectController;
        private int selectedMarkId = -1;
        public MarksForm()
        {
            InitializeComponent();
            markController = new MarkController();
            CourseControll = new CourseController();
            subjectController = new SubjectControllers();

            MarkdataGridView.SelectionChanged += MarkdataGridView_SelectionChanged;
            this.Load += MarksForm_Load;
            MarkScore.TextChanged += MarkScore_TextChanged;
            LoadCourses();
            LoadSubjects();

        }

        private void MarkScore_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(MarkScore.Text.Trim(), out int score))
            {
                Markgrade.Text = GetGradeFromScore(score);
            }
            else
            {
                Markgrade.Text = string.Empty;
            }
        }

        private void LoadCourses()
        {
            var Courses = CourseControll.GetAllCourse();
            CoursecomboBox.DataSource = Courses;
            CoursecomboBox.DisplayMember = "CourseName";
            CoursecomboBox.ValueMember = "CourseID";
        }
        private void LoadSubjects()
        {
            var subjects = subjectController.GetAllSubject();
            SelectcomboBox.DataSource = subjects;
            SelectcomboBox.DisplayMember = "Subname";
            SelectcomboBox.ValueMember = "SubID";
        }

        private void LoadStudents()
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT StdId, StdName FROM Students";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    MarkcomboBox.DataSource = dt;
                    MarkcomboBox.DisplayMember = "StdName";
                    MarkcomboBox.ValueMember = "StdId";
                }
            }
        }

        private void LoadData()
        {
            var marks = markController.GetAllMarks();
            MarkdataGridView.DataSource = marks;
        }


        private void MarkdataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (MarkdataGridView.SelectedRows.Count > 0)
            {
                var row = MarkdataGridView.SelectedRows[0];
                var mark = row.DataBoundItem as Mark;

                if (mark != null)
                {
                    selectedMarkId = mark.MaID;

                    var selected = markController.GetMarkById(selectedMarkId);
                    if (selected != null)
                    {
                        // Update ComboBoxes instead of TextBoxes
                        MarkScore.Text = selected.Mamark;
                        Markgrade.Text = selected.Magrade;

                        // Subject selection using SubID
                        if (selected.StdID != 0)
                        {
                            MarkcomboBox.SelectedValue = selected.StdID;
                            CoursecomboBox.SelectedValue = selected.CourseId;
                            SelectcomboBox.SelectedValue = selected.SubjectId;
                        }
                    }
                }
            }
        }

        private void ClearForm()
        {
            MarkScore.Clear();
            MarkScore.Clear();
            MarkcomboBox.SelectedIndex = -1;
            selectedMarkId = -1;
            CoursecomboBox.SelectedIndex = -1;
            SelectcomboBox.SelectedIndex = -1;
        }


        private void MarksForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadData();
            
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (MarkcomboBox.SelectedValue == null ||
        string.IsNullOrWhiteSpace(MarkScore.Text) ||
        string.IsNullOrWhiteSpace(Markgrade.Text))
    {
        MessageBox.Show("All fields are required.");
        return;
    }

            var mark = new Mark
            {
                Mamark = MarkScore.Text,
                Magrade = Markgrade.Text,
                CourseId = Convert.ToInt32(CoursecomboBox.SelectedValue),
                SubjectId = Convert.ToInt32(SelectcomboBox.SelectedValue),
                StdID = Convert.ToInt32(MarkcomboBox.SelectedValue)
            };

            markController.AddMark(mark);
            LoadData();
            ClearForm();
            MessageBox.Show("Mark added successfully.");
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MarkScore.Text) || string.IsNullOrWhiteSpace(Markgrade.Text))
            {
                MessageBox.Show("Please enter or select both Class Score and Grade.");
                return;
            }

            var mark = new Mark
            {
                MaID = selectedMarkId,
                Mamark = MarkScore.Text?.Trim(),
                Magrade = Markgrade.Text?.Trim(),
                CourseId = Convert.ToInt32(CoursecomboBox.SelectedValue),
                SubjectId = Convert.ToInt32(SelectcomboBox.SelectedValue),
                StdID = Convert.ToInt32(MarkcomboBox.SelectedValue)
            };

            markController.UpdateMark(mark);
            LoadData();
            ClearForm();
            MessageBox.Show("Marks updated successfully.");
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (selectedMarkId == -1)
            {
                MessageBox.Show("Select a row to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this class?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
                {
                markController.DeleteMark(selectedMarkId);
                LoadData();
                ClearForm();
                MessageBox.Show("Mark deleted successfully.");
            }


        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string subjectName = MarkScore.Text?.Trim(); // Using MarkScore textbox as search input

            if (!string.IsNullOrEmpty(subjectName))
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT m.MarksId, m.MarkScore, m.MarksGrade,
                       s.StdId, s.StdName,
                       c.CouId, c.CouName,
                       sub.SubjectId, sub.SubjectName
                FROM Marks m
                JOIN Students s ON m.StdId = s.StdId
                JOIN Courses c ON m.CourseId = c.CouId
                JOIN Subjects sub ON m.SubjectId = sub.SubjectId
                WHERE sub.SubjectName LIKE @subjectName
                LIMIT 1";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@subjectName", $"%{subjectName}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedMarkId = Convert.ToInt32(reader["MarksId"]);

                                // Populate fields
                                MarkScore.Text = reader["MarkScore"].ToString();
                                Markgrade.Text = reader["MarksGrade"].ToString();

                                // Set selected student, course, and subject
                                MarkcomboBox.SelectedValue = Convert.ToInt32(reader["StdId"]);
                                CoursecomboBox.SelectedValue = Convert.ToInt32(reader["CouId"]);
                                SelectcomboBox.SelectedValue = Convert.ToInt32(reader["SubjectId"]);
                            }
                            else
                            {
                                MessageBox.Show("No marks found for that subject.");
                                ClearForm();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter a subject name to search.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void MarkdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = MarkdataGridView.Rows[e.RowIndex];
                selectedMarkId = Convert.ToInt32(row.Cells["MaID"].Value);
                MarkScore.Text = row.Cells["Mamark"].Value.ToString();
                Markgrade.Text = row.Cells["Magrade"].Value.ToString();
                MarkcomboBox.Text = row.Cells["Stdname"].Value.ToString();
            }
        }

        private string GetGradeFromScore(int score)
        {
            if (score >= 90) return "A+";
            else if (score >= 80) return "A";
            else if (score >= 70) return "B";
            else if (score >= 60) return "C";
            else if (score >= 50) return "D";
            else return "F";
        }
    }
}
