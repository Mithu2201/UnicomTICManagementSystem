using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem
{
    public partial class StudentTimetableForm : Form
    {
        private readonly string userRole;
        private readonly int userId;
        private readonly StudentTimeTableController controller = new StudentTimeTableController();

        public StudentTimetableForm(int loggedUserId, string role)
        {
            InitializeComponent();
            userId = loggedUserId;
            userRole = role;

            StdTicomboBox.SelectedIndexChanged += StdTicomboBox_SelectedIndexChanged;
        }

        private void StudentTimetableForm_Load(object sender, EventArgs e)
        {
            if (userRole == "Student")
            {
                StdTiSearch.Enabled = false;
                StdTiSearch.Visible = false;
                StdTiSearchBtn.Visible = false;
                label1.Visible = false;

                LoadStudentDetailsByUserId(userId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(StdTiSearch.Text.Trim(), out int studentId))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            var result = controller.GetStudentDetailsByStudentId(studentId);
            if (result != null)
            {
                var (courseId, stdName, phone, address, courseName) = result.Value;

                StdTiName.Text = stdName;
                StdTiPhone.Text = phone;
                StdTiAddress.Text = address;
                StdTiCourse.Text = courseName;

                LoadSubjectsForCourse(courseId);
            }
            else
            {
                MessageBox.Show("Student not found.");
            }
        }

        private void LoadStudentDetailsByUserId(int uid)
        {
            var result = controller.GetStudentDetailsByUserId(uid);
            if (result != null)
            {
                var (courseId, stdName, phone, address, courseName) = result.Value;

                StdTiName.Text = stdName;
                StdTiPhone.Text = phone;
                StdTiAddress.Text = address;
                StdTiCourse.Text = courseName;

                LoadSubjectsForCourse(courseId);
            }
            else
            {
                MessageBox.Show("Student record not found.");
            }
        }

        private void LoadSubjectsForCourse(int courseId)
        {
            StdTicomboBox.Items.Clear();
            var subjectList = controller.GetSubjectsForCourse(courseId);

            foreach (var subject in subjectList)
            {
                StdTicomboBox.Items.Add(subject.Item2); 
            }

            StdTicomboBox.Tag = subjectList;

            if (StdTicomboBox.Items.Count > 0)
                StdTicomboBox.SelectedIndex = 0;
        }

        private void StdTicomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StdTicomboBox.SelectedItem == null || StdTicomboBox.Tag == null)
                return;

            var subjectList = StdTicomboBox.Tag as List<Tuple<int, string>>;
            string selectedName = StdTicomboBox.SelectedItem.ToString();
            var selectedSubject = subjectList.FirstOrDefault(s => s.Item2 == selectedName);

            if (selectedSubject == null) return;

            int subjectId = selectedSubject.Item1;
            var timetable = controller.GetTimeTableBySubjectId(subjectId);

            StdTidataGridView.DataSource = timetable;

            if (StdTidataGridView.Columns.Count >= 3)
            {
                StdTidataGridView.Columns["TimeDay"].HeaderText = "Start Session";
                StdTidataGridView.Columns["TimeSlot"].HeaderText = "End Session";
                StdTidataGridView.Columns["RoomName"].HeaderText = "Room";
            }
        }

        private void StdTidataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
