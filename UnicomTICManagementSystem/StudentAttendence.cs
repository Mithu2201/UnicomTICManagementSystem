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
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem
{
    public partial class StudentAttendence : Form
    {
        private readonly int loggedInUserId;
        private readonly string userRole;
        public StudentAttendence()
        {
            InitializeComponent();
            
            StdAtcomboBox.SelectedIndexChanged += (s, e) => LoadStudentAttendance();
            StdAtdateTimePicker.ValueChanged += (s, e) => LoadStudentAttendance();
            StdTiSearchBtn.Click += StdTiSearchBtn_Click;
        }

        private void StudentAttendence_Load(object sender, EventArgs e)
        {

        }

        private void StdTiSearchBtn_Click(object sender, EventArgs e)
        {
            string studentIdText = StdAtSearch.Text.Trim();

            if (!int.TryParse(studentIdText, out int studentId))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT StdName, StdAddress, StdPhone FROM Students WHERE StdId = @StdId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            StdAtName.Text = reader["StdName"].ToString();
                            StdAtAddress.Text = reader["StdAddress"].ToString();
                            StdAtPhone.Text = reader["StdPhone"].ToString();

                            LoadSubjectsForStudent(studentId); // Populate Subject ComboBox
                        }
                        else
                        {
                            MessageBox.Show("Student not found.");
                        }
                    }
                }
            }
        }

        private void LoadSubjectsForStudent(int studentId)
        {
            StdAtcomboBox.Items.Clear();
            var subjectList = new List<Tuple<int, string>>();

            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
            SELECT DISTINCT sub.SubjectId, sub.SubjectName
            FROM Subjects sub
            JOIN Marks m ON sub.CourseId = m.CourseId
            WHERE m.StdId = @StdId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);

                            subjectList.Add(Tuple.Create(id, name));
                            StdAtcomboBox.Items.Add(name);
                        }
                    }
                }
            }

            StdAtcomboBox.Tag = subjectList; // Store IDs for later use
        }


        private void LoadStudentAttendance()
        {
            if (StdAtcomboBox.SelectedItem == null || StdAtcomboBox.Tag == null)
                return;

            var subjectList = StdAtcomboBox.Tag as List<Tuple<int, string>>;
            string selectedSubjectName = StdAtcomboBox.SelectedItem.ToString();
            var selectedSubject = subjectList.FirstOrDefault(s => s.Item2 == selectedSubjectName);
            if (selectedSubject == null) return;

            int subjectId = selectedSubject.Item1;
            int studentId;

            if (!int.TryParse(StdAtSearch.Text.Trim(), out studentId))
            {
                MessageBox.Show("Invalid student ID.");
                return;
            }

            string selectedDateString = StdAtdateTimePicker.Value.ToString("D"); // e.g., Thursday, June 19, 2025

            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
            SELECT Date, 
                   (SELECT SubjectName FROM Subjects WHERE SubjectId = a.SubjectId) AS Subject,
                   (SELECT StatusName FROM AddStatus WHERE StatusId = a.StatusId) AS Status
            FROM Attendances a
            WHERE a.StdId = @StdId AND a.SubjectId = @SubId AND a.Date = @Date";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentId);
                    cmd.Parameters.AddWithValue("@SubId", subjectId);
                    cmd.Parameters.AddWithValue("@Date", selectedDateString); // Match with stored format

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        StdAtdataGridView.DataSource = dt;
                    }
                }
            }

        }
    }
}
