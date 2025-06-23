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
    public partial class TimeTablesForm : Form
    {
        private readonly TimetableController TimeControll;
        private readonly RoomController RoomControll;
        private readonly AddTimeController addTimeController = new AddTimeController();
        private readonly CourseController CourseControll;
        private readonly SubjectControllers subjectController;

        private int selectedTimeId = -1;
        public TimeTablesForm()
        {
            InitializeComponent();
            LoadRoomsToComboBox();
            TimeControll = new TimetableController();
            RoomControll = new RoomController();
            CourseControll = new CourseController();
            subjectController = new SubjectControllers();

            this.Load += TimeTablesForm_Load;
            TimedataGridView.SelectionChanged += TimedataGridView_SelectionChanged;
            

            LoadTimetables();
            LoadCourses();
            LoadSubjects();

        }

        private void LoadTimetables()
        {
            TimedataGridView.DataSource = null;
            TimedataGridView.DataSource = TimeControll.GetAllTimetables();

            if (TimedataGridView.Columns.Contains("RoID"))
                TimedataGridView.Columns["RoID"].Visible = false;

            if (TimedataGridView.Columns.Contains("CourseID"))
                TimedataGridView.Columns["CourseID"].Visible = false;

            if (TimedataGridView.Columns.Contains("SubID"))
                TimedataGridView.Columns["SubID"].Visible = false;

            if (TimedataGridView.Columns.Contains("LecID"))
                TimedataGridView.Columns["LecID"].Visible = false;

            TimedataGridView.ClearSelection();
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

        private void LoadLectures()
        {
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT LecId, LecName FROM lectures", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);

                    LecturecomboBox.DisplayMember = "LecName";
                    LecturecomboBox.ValueMember = "LecId";
                    LecturecomboBox.DataSource = dt;
                }
            }
        }



        private void ClearForm()
        {
            TiDaycomboBox.SelectedIndex = -1;
            TiSlotcomboBox.SelectedIndex = -1;
            TimecomboBox.SelectedIndex = -1;
            CoursecomboBox.SelectedIndex = -1;
            SelectcomboBox.SelectedIndex = -1;

            TiDaycomboBox.Text = "";
            TiSlotcomboBox.Text = "";
            TimecomboBox.Text = "";
            selectedTimeId = -1;
        }

        private void TimedataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (TimedataGridView.SelectedRows.Count > 0)
            {
                var row = TimedataGridView.SelectedRows[0];
                var time = row.DataBoundItem as Timetable;

                if (time != null)
                {
                    selectedTimeId = time.TiID;
                    var fullTime = TimeControll.GetTimetableById(selectedTimeId);

                    TiDaycomboBox.Text = fullTime.Tiday;
                    TiSlotcomboBox.Text = fullTime.Tislot;
                    TimecomboBox.SelectedValue = fullTime.RoID;
                    CoursecomboBox.SelectedValue = fullTime.CourseID;
                    SelectcomboBox.SelectedValue = fullTime.SubID;
                }
            }
            else
            {
                ClearForm();
            }
        }

        private void TimeTablesForm_Load(object sender, EventArgs e)
        {
            LoadTimeComboBoxes();
            LoadLectures();
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TiDaycomboBox.Text) || string.IsNullOrWhiteSpace(TiSlotcomboBox.Text))
            {
                MessageBox.Show("Please Select All Values.");
                return;
            }

            if (TimecomboBox.SelectedValue == null || CoursecomboBox.SelectedValue == null || SelectcomboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select All Values.");
                return;
            }

            using (var conn = Dbconfig.GetConnection())
            {
                string checkQuery = @"
            SELECT COUNT(*) FROM TimeTables
            WHERE 
            (LecID = @LecID AND TimeDay = @TimeDay AND TimeSlot = @TimeSlot)
            OR
            (RoomId = @RoomId AND TimeDay = @TimeDay AND TimeSlot = @TimeSlot)";

                using (var cmd = new SQLiteCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@LecID", LecturecomboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@RoomId", TimecomboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@TimeDay", TiDaycomboBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@TimeSlot", TiSlotcomboBox.Text.Trim());

                    int conflictCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (conflictCount > 0)
                    {
                        MessageBox.Show("Conflict: Either the room or lecturer is already assigned for the same day and time slot.", "Conflict Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            var time = new Timetable
            {
                Tiday = TiDaycomboBox.Text,
                Tislot = TiSlotcomboBox.Text,
                RoID = Convert.ToInt32(TimecomboBox.SelectedValue),
                CourseID = Convert.ToInt32(CoursecomboBox.SelectedValue),
                SubID = Convert.ToInt32(SelectcomboBox.SelectedValue),
                LecID = Convert.ToInt32(LecturecomboBox.SelectedValue)
            };

            TimeControll.AddTimetable(time);
            LoadTimetables();
            ClearForm();
            MessageBox.Show("Timetable Added Successfully");
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedTimeId == -1)
            {
                MessageBox.Show("Please select a timetable to update.");
                return;
            }

            if (TimecomboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid room.");
                return;
            }

            var time = new Timetable
            {
                TiID = selectedTimeId,
                Tiday = TiDaycomboBox.Text,
                Tislot = TiSlotcomboBox.Text,
                RoID = Convert.ToInt32(TimecomboBox.SelectedValue),
                CourseID = Convert.ToInt32(CoursecomboBox.SelectedValue),
                SubID = Convert.ToInt32(SelectcomboBox.SelectedValue),
                LecID = Convert.ToInt32(LecturecomboBox.SelectedValue)
            };

            TimeControll.UpdateTimetable(time);
            LoadTimetables();
            ClearForm();
            MessageBox.Show("Timetable Updated Successfully");
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (selectedTimeId == -1)
            {
                MessageBox.Show("Please select a timetable to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                TimeControll.DeleteTimetable(selectedTimeId);
                LoadTimetables();
                ClearForm();
                MessageBox.Show("Deleted Successfully");
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchSubject = SelectcomboBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchSubject))
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    string query = @"
                SELECT t.TimeId, t.TimeDay, t.TimeSlot, t.RoomId, r.RooomName, s.SubjectId, s.SubjectName
                FROM TimeTables t
                LEFT JOIN Rooms r ON t.RoomId = r.RoomId
                LEFT JOIN Subjects s ON t.SubID = s.SubjectId
                WHERE s.SubjectName LIKE @SubjectName
                LIMIT 1";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubjectName", $"%{searchSubject}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedTimeId = Convert.ToInt32(reader["TimeId"]);
                                TiDaycomboBox.Text = reader["TimeDay"].ToString();
                                TiSlotcomboBox.Text = reader["TimeSlot"].ToString();

                                int roomId = Convert.ToInt32(reader["RoomId"]);
                                TimecomboBox.SelectedValue = roomId;

                                int subjectId = Convert.ToInt32(reader["SubjectId"]);
                                SelectcomboBox.SelectedValue = subjectId;
                            }
                            else
                            {
                                MessageBox.Show("Timetable for the selected subject not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearForm();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a subject to search.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadRoomsToComboBox()
        {
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT RoomId, RoomMode FROM Rooms", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);

                    TimecomboBox.DisplayMember = "RoomMode";
                    TimecomboBox.ValueMember = "RoomId";
                    TimecomboBox.DataSource = dt;
                }
            }
        }

        

        private void LoadTimeComboBoxes()
        {
            var times = addTimeController.GetTimeDaysAndSlots();

            TiDaycomboBox.Items.Clear();
            TiSlotcomboBox.Items.Clear();

            foreach (var time in times)
            {
                if (!TiDaycomboBox.Items.Contains(time.AddTimeCode))
                    TiDaycomboBox.Items.Add(time.AddTimeCode);

                if (!TiSlotcomboBox.Items.Contains(time.AddTimeName))
                    TiSlotcomboBox.Items.Add(time.AddTimeName);
            }
        }


    }
}
