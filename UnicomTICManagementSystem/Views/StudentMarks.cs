using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem
{
    public partial class StudentMarks : Form
    {
        private readonly int userId;
        private readonly string userRole;
        private StudentMarkController _controller;
        private List<SubjectItem> _subjects;

        public StudentMarks(int loggedUserId, string role)
        {
            InitializeComponent();
            userId = loggedUserId;
            userRole = role;

            _controller = new StudentMarkController();

            StdMarkcomboBox.SelectedIndexChanged += StdMarkcomboBox_SelectedIndexChanged;
        }

        private void StudentMarks_Load(object sender, EventArgs e)
        {
            if (userRole == "Student")
            {
                // Hide search controls
                StdMarkSearch.Enabled = false;
                StdMarkSearch.Visible = false;
                button1.Visible = false;
                label1.Visible = false;

                LoadStudentDetailsByUserId(userId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentIdText = StdMarkSearch.Text.Trim();

            if (int.TryParse(studentIdText, out int stdId))
            {
                LoadStudentDetailsByStdId(stdId);
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
            }
        }

        private void LoadStudentDetailsByUserId(int uid)
        {
            var student = _controller.GetStudentDetailsByUserId(uid);
            if (student != null)
            {
                PopulateStudentDetails(student);
                LoadSubjects(student.CourseId);
                StdMarkSearch.Text = student.StdId.ToString();
            }
            else
            {
                MessageBox.Show("Student not found.");
            }
        }

        private void LoadStudentDetailsByStdId(int stdId)
        {
            var student = _controller.GetStudentDetailsByStdId(stdId);
            if (student != null)
            {
                PopulateStudentDetails(student);
                LoadSubjects(student.CourseId);
            }
            else
            {
                MessageBox.Show("No student found.");
            }
        }

        private void PopulateStudentDetails(StudentMarkModel student)
        {
            StdMarkName.Text = student.StdName;
            StdMarkAddress.Text = student.StdAddress;
            StdMarkPhone.Text = student.StdPhone;
            StdMarkCourse.Text = student.CourseName;
        }

        private void LoadSubjects(int courseId)
        {
            _subjects = _controller.GetSubjectsByCourseId(courseId);
            StdMarkcomboBox.Items.Clear();

            foreach (var subject in _subjects)
            {
                StdMarkcomboBox.Items.Add(subject);
            }

            if (StdMarkcomboBox.Items.Count > 0)
            {
                StdMarkcomboBox.SelectedIndex = 0;
            }
        }

        private void StdMarkcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StdMarkcomboBox.SelectedItem is SubjectItem selectedSubject)
            {
                if (!int.TryParse(StdMarkSearch.Text.Trim(), out int studentId))
                {
                    MessageBox.Show("Welcome.");
                    return;
                }

                DataTable dt = _controller.GetMarksByStudentAndSubject(studentId, selectedSubject.SubjectId);
                StdMarkdataGridView.DataSource = dt;
            }
        }
    }
}
