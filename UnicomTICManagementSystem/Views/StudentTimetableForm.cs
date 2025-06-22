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
    public partial class StudentTimetableForm : Form
    {
        private readonly string userRole;
        private readonly int userId;
        public StudentTimetableForm(int loggedUserId, string role)
        {
            InitializeComponent();
            StdTicomboBox.SelectedIndexChanged += StdTicomboBox_SelectedIndexChanged;

            userId = loggedUserId;
            userRole = role;
        }

        private void StudentTimetableForm_Load(object sender, EventArgs e)
        {
            if (userRole == "Student")
            {
                // Hide manual search controls
                StdTiSearch.Enabled = false;
                StdTiSearch.Visible = false;
                StdTiSearchBtn.Visible = false;

                // Load current student's timetable
                LoadStudentDetailsByUserId(userId);
            }

        }

        private void LoadStudentDetailsByUserId(int uid)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
            SELECT s.StdId, s.StdName, s.StdPhone, s.StdAddress, c.CouId, c.CouName
            FROM Students s
            JOIN Marks m ON s.StdId = m.StdId
            JOIN Courses c ON m.CourseId = c.CouId
            WHERE s.UserId = @UserId
            LIMIT 1;
        ";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", uid);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            StdTiName.Text = reader["StdName"].ToString();
                            StdTiPhone.Text = reader["StdPhone"].ToString();
                            StdTiAddress.Text = reader["StdAddress"].ToString();
                            StdTiCourse.Text = reader["CouName"].ToString();

                            int courseId = Convert.ToInt32(reader["CouId"]);
                            LoadSubjectsForCourse(courseId);
                        }
                        else
                        {
                            MessageBox.Show("Student record not found.");
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userRole == "Student")
            {
                MessageBox.Show("Access denied. Students can only view their own timetable.");
                return;
            }

            string studentIdText = StdTiSearch.Text.Trim();
            if (!int.TryParse(studentIdText, out int studentId))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            using (var conn = Dbconfig.GetConnection())
            {
                string studentQuery = @"
            SELECT s.StdName, s.StdPhone, s.StdAddress, c.CouId, c.CouName
            FROM Students s
            JOIN Marks m ON s.StdId = m.StdId
            JOIN Courses c ON m.CourseId = c.CouId
            WHERE s.StdId = @StdId
            LIMIT 1;
        ";

                using (var cmd = new SQLiteCommand(studentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            StdTiName.Text = reader["StdName"].ToString();
                            StdTiPhone.Text = reader["StdPhone"].ToString();
                            StdTiAddress.Text = reader["StdAddress"].ToString();
                            StdTiCourse.Text = reader["CouName"].ToString();

                            int courseId = Convert.ToInt32(reader["CouId"]);
                            LoadSubjectsForCourse(courseId);
                        }
                        else
                        {
                            MessageBox.Show("Student not found.");
                        }
                    }
                }
            }
        }

        private void LoadSubjectsForCourse(int courseId)
        {
            StdTicomboBox.Items.Clear();

            using (var conn = Dbconfig.GetConnection())
            {
                
                string query = "SELECT SubjectId, SubjectName FROM Subjects WHERE CourseId = @CourseId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var subjectList = new List<Tuple<int, string>>();
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            subjectList.Add(Tuple.Create(id, name));
                            StdTicomboBox.Items.Add(name); // Show name
                        }

                        // Store subject list in ComboBox Tag for later lookup
                        StdTicomboBox.Tag = subjectList;
                    }
                }
            }
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

            using (var conn = Dbconfig.GetConnection())
            {
                

                string query = @"
            SELECT tt.TimeDay, tt.TimeSlot, r.RooomName
            FROM TimeTables tt
            JOIN Rooms r ON tt.RoomId = r.RoomId
            WHERE tt.SubID = @SubId
        ";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubId", subjectId);
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        StdTidataGridView.DataSource = dt;

                        // Optionally set column headers
                        StdTidataGridView.Columns["TimeDay"].HeaderText = "Day";
                        StdTidataGridView.Columns["TimeSlot"].HeaderText = "Time Slot";
                        StdTidataGridView.Columns["RooomName"].HeaderText = "Room";
                    }
                }
            }
        }
    }
}
