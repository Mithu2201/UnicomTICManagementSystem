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
                MessageBox.Show("Please select all values.");
                return;
            }

            if (TimecomboBox.SelectedValue == null || CoursecomboBox.SelectedValue == null ||
                SelectcomboBox.SelectedValue == null || LecturecomboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select all values.");
                return;
            }

            int roomId = Convert.ToInt32(TimecomboBox.SelectedValue);
            int lecId = Convert.ToInt32(LecturecomboBox.SelectedValue);
            string timeDay = TiDaycomboBox.Text.Trim();
            string timeSlot = TiSlotcomboBox.Text.Trim();

            
            if (TimeControll.IsConflictExists(roomId, lecId, timeDay, timeSlot))
            {
                MessageBox.Show("Conflict: Either the room or lecturer is already assigned for the same day and time slot.", "Conflict Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            var time = new Timetable
            {
                Tiday = timeDay,
                Tislot = timeSlot,
                RoID = roomId,
                CourseID = Convert.ToInt32(CoursecomboBox.SelectedValue),
                SubID = Convert.ToInt32(SelectcomboBox.SelectedValue),
                LecID = lecId
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
                var result = TimeControll.SearchTimetableBySubjectName(searchSubject);

                if (result != null)
                {
                    selectedTimeId = result.TiID;
                    TiDaycomboBox.Text = result.Tiday;
                    TiSlotcomboBox.Text = result.Tislot;
                    TimecomboBox.SelectedValue = result.RoID;
                    CoursecomboBox.SelectedValue = result.CourseID;
                    SelectcomboBox.SelectedValue = result.SubID;
                    LecturecomboBox.SelectedValue = result.LecID;
                }
                else
                {
                    MessageBox.Show("Timetable for the selected subject not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
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
