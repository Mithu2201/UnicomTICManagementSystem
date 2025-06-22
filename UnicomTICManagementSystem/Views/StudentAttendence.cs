using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem
{
    public partial class StudentAttendence : Form
    {
        private readonly int loggedInUserId;
        private readonly string userRole;

        private StudentAttendanceController _controller;
        private List<(int SubjectId, string SubjectName)> _subjectList;

        public StudentAttendence(int userId, string role)
        {
            InitializeComponent();

            loggedInUserId = userId;
            userRole = role;

            _controller = new StudentAttendanceController();

            StdAtcomboBox.SelectedIndexChanged += (s, e) => LoadStudentAttendance();
            StdAtdateTimePicker.ValueChanged += (s, e) => LoadStudentAttendance();
            StdTiSearchBtn.Click += StdTiSearchBtn_Click;
        }

        private void StudentAttendence_Load(object sender, EventArgs e)
        {
            if (userRole == "Student")
            {
                // Hide and disable search controls for student
                StdAtSearch.Enabled = false;
                StdAtSearch.Visible = false;
                StdTiSearchBtn.Visible = false;
                label1.Visible = false;

                LoadLoggedInStudentDetails();
            }
        }

        private void LoadLoggedInStudentDetails()
        {
            var student = _controller.GetStudentDetailsByUserId(loggedInUserId);
            if (student != null)
            {
                StdAtSearch.Text = student.StdId.ToString();
                StdAtName.Text = student.StdName;
                StdAtAddress.Text = student.StdAddress;
                StdAtPhone.Text = student.StdPhone;

                LoadSubjectsForStudent(student.StdId);
            }
            else
            {
                MessageBox.Show("Student record not found.");
            }
        }

        private void StdTiSearchBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(StdAtSearch.Text.Trim(), out int studentId))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            var student = _controller.GetStudentDetailsById(studentId);
            if (student != null)
            {
                StdAtName.Text = student.StdName;
                StdAtAddress.Text = student.StdAddress;
                StdAtPhone.Text = student.StdPhone;

                LoadSubjectsForStudent(studentId);
            }
            else
            {
                MessageBox.Show("Student not found.");
            }
        }

        private void LoadSubjectsForStudent(int studentId)
        {
            StdAtcomboBox.Items.Clear();
            _subjectList = _controller.GetSubjectsForStudent(studentId);

            foreach (var subject in _subjectList)
            {
                StdAtcomboBox.Items.Add(subject.SubjectName);
            }

            if (StdAtcomboBox.Items.Count > 0)
            {
                StdAtcomboBox.SelectedIndex = 0;
            }
        }

        private void LoadStudentAttendance()
        {
            if (StdAtcomboBox.SelectedItem == null || _subjectList == null)
                return;

            string selectedSubjectName = StdAtcomboBox.SelectedItem.ToString();
            var selectedSubject = _subjectList.FirstOrDefault(s => s.SubjectName == selectedSubjectName);
            if (selectedSubject == default) return;

            int subjectId = selectedSubject.SubjectId;
            int studentId;

            if (userRole == "Student")
            {
                if (!int.TryParse(StdAtSearch.Text.Trim(), out studentId))
                {
                    MessageBox.Show("Invalid student ID.");
                    return;
                }
            }
            else
            {
                if (!int.TryParse(StdAtSearch.Text.Trim(), out studentId))
                {
                    MessageBox.Show("Please enter a valid student ID.");
                    return;
                }
            }

            string selectedDateString = StdAtdateTimePicker.Value.ToString("D");

            DataTable attendanceData = _controller.GetAttendanceRecords(studentId, subjectId, selectedDateString);
            StdAtdataGridView.DataSource = attendanceData;
        }
    }
}
