using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem
{
    public partial class StudentMarks : Form
    {
        private readonly int userId;
        private readonly string userRole;
        public StudentMarks(int loggedUserId, string role)
        {
            InitializeComponent();
            userId = loggedUserId;
            userRole = role;
            StdMarkcomboBox.SelectedIndexChanged += StdMarkcomboBox_SelectedIndexChanged;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userRole == "Student")
            {
                MessageBox.Show("Access denied. Students can only view their own marks.");
                return;
            }

            string studentId = StdMarkSearch.Text.Trim();

            if (!string.IsNullOrEmpty(studentId))
            {
                if (int.TryParse(studentId, out int stdId))
                {
                    LoadStudentDetailsByStdId(stdId);
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric Student ID.");
                }
            }
        
        }

        

        private void StudentMarks_Load(object sender, EventArgs e)
        {
            if (userRole == "Student")
            {
                // Hide search controls
                StdMarkSearch.Enabled = false;
                StdMarkSearch.Visible = false;
                button1.Visible = false;

                // Load own student details
                LoadStudentDetailsByUserId(userId);
            }

        }

        private void LoadStudentDetailsByUserId(int uid)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
                SELECT s.StdId, s.StdName, s.StdAddress, s.StdPhone,
                       c.CouName, c.CouId
                FROM Students s
                JOIN Marks m ON s.StdId = m.StdId
                JOIN Courses c ON m.CourseId = c.CouId
                WHERE s.UserId = @UserId
                LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", uid);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int stdId = Convert.ToInt32(reader["StdId"]);
                            PopulateStudentDetails(reader);
                            LoadSubjectsIntoComboBox(Convert.ToInt32(reader["CouId"]));
                            StdMarkSearch.Text = stdId.ToString(); // So the combobox can use it
                        }
                        else
                        {
                            MessageBox.Show("Student not found.");
                        }
                    }
                }
            }
        }

        private void LoadStudentDetailsByStdId(int stdId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = @"
                SELECT s.StdName, s.StdAddress, s.StdPhone,
                       c.CouName, c.CouId
                FROM Students s
                JOIN Marks m ON s.StdId = m.StdId
                JOIN Courses c ON m.CourseId = c.CouId
                WHERE s.StdId = @StdId
                LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StdId", stdId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PopulateStudentDetails(reader);
                            LoadSubjectsIntoComboBox(Convert.ToInt32(reader["CouId"]));
                        }
                        else
                        {
                            MessageBox.Show("No student found.");
                        }
                    }
                }
            }
        }

        private void PopulateStudentDetails(SQLiteDataReader reader)
        {
            StdMarkName.Text = reader["StdName"].ToString();
            StdMarkAddress.Text = reader["StdAddress"].ToString();
            StdMarkPhone.Text = reader["StdPhone"].ToString();
            StdMarkCourse.Text = reader["CouName"].ToString();
        }

        private void LoadSubjectsIntoComboBox(int courseId)
        {
            StdMarkcomboBox.Items.Clear();

            using (var conn = Dbconfig.GetConnection())
            {
                string subjectQuery = "SELECT SubjectId, SubjectName FROM Subjects WHERE CourseId = @CourseId";

                using (var cmd = new SQLiteCommand(subjectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var subjectId = Convert.ToInt32(reader["SubjectId"]);
                            var subjectName = reader["SubjectName"].ToString();

                            StdMarkcomboBox.Items.Add(new ComboBoxItem
                            {
                                Text = subjectName,
                                Value = subjectId
                            });
                        }
                    }
                }
            }

            if (StdMarkcomboBox.Items.Count > 0)
                StdMarkcomboBox.SelectedIndex = 0;
        }

        private void StdMarkcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StdMarkcomboBox.SelectedItem is ComboBoxItem selectedSubject)
            {
                int subjectId = selectedSubject.Value;
                int studentId;

                if (!int.TryParse(StdMarkSearch.Text.Trim(), out studentId))
                {
                    MessageBox.Show(" Student.");
                    return;
                }

                using (var conn = Dbconfig.GetConnection())
                {
                    string query = @"
            SELECT e.ExamName, m.MarkScore, m.MarksGrade
            FROM Marks m
            JOIN Exams e ON m.SubjectId = e.SubjectID
            WHERE m.StdId = @StdId AND m.SubjectId = @SubId";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StdId", studentId);
                        cmd.Parameters.AddWithValue("@SubId", subjectId);

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            StdMarkdataGridView.DataSource = dt;
                        }
                    }
                }
            }
        }

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
