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

namespace UnicomTICManagementSystem
{
    
    public partial class AttendenceForm : Form
    {
        private readonly AttendController attendControll;
        private readonly StudentController StudentControll;
        private readonly AddStatusController AddStatusControll;
        private readonly SubjectControllers subjectController;

        private int selectedAttendId = -1;

        private int? loggedInStudentId = null;
        public AttendenceForm(int? studentId = null)
        {
            InitializeComponent();
            loggedInStudentId = studentId;
            StudentControll = new StudentController();
            AddStatusControll = new AddStatusController();
            subjectController = new SubjectControllers();
            attendControll = new AttendController();

            this.Load += AttendenceForm_Load;
            AttenddataGridView.SelectionChanged += AttenddataGridView_SelectionChanged;
            Ssearch.Click += Ssearch_Click;

            LoadAttendtables();
            LoadStudents();
            LoadSubjects();
            LoadStatus();
        }

        private void LoadAttendtables()
        {
            if (loggedInStudentId.HasValue)
            {
                // Only load attendance for logged-in student
                AttenddataGridView.DataSource = attendControll
                    .GetAllStatusAll()
                    .Where(a => a.StudentID == loggedInStudentId.Value)
                    .ToList();
            }
            else
            {
                
                AttenddataGridView.DataSource = attendControll.GetAllStatusAll();
            }

            
            if (AttenddataGridView.Columns.Contains("AttendID"))
                AttenddataGridView.Columns["AttendID"].Visible = false;
            if (AttenddataGridView.Columns.Contains("StatusID"))
                AttenddataGridView.Columns["StatusID"].Visible = false;
            if (AttenddataGridView.Columns.Contains("SubID"))
                AttenddataGridView.Columns["SubID"].Visible = false;
            if (AttenddataGridView.Columns.Contains("StudentID"))
                AttenddataGridView.Columns["StudentID"].Visible = false;

            AttenddataGridView.ClearSelection();
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

                    AttStucomboBox.DataSource = dt;
                    AttStucomboBox.DisplayMember = "StdName";
                    AttStucomboBox.ValueMember = "StdId";
                }
            }
        }

        private void LoadSubjects()
        {
            var subjects = subjectController.GetAllSubject();
            AttSubcomboBox.DataSource = subjects;
            AttSubcomboBox.DisplayMember = "Subname";
            AttSubcomboBox.ValueMember = "SubID";
        }

        private void LoadStatus()
        {
            var status = AddStatusControll.GetAllStatus();
            AttStacomboBox.DataSource = status;
            AttStacomboBox.DisplayMember = "AddStatusName";
            AttStacomboBox.ValueMember = "AddStatusID";
        }

        private void ClearForm()
        {
            AttStucomboBox.SelectedIndex = -1;
            AttSubcomboBox.SelectedIndex = -1;
            AttStacomboBox.SelectedIndex = -1;
            dateTimePicker.Value = DateTime.Now;

            AttStucomboBox.Text = "";
            AttSubcomboBox.Text = "";
            AttStacomboBox.Text = "";
            selectedAttendId = -1;
        }

        private void AttenddataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (AttenddataGridView.SelectedRows.Count > 0)
            {
                var row = AttenddataGridView.SelectedRows[0];
                var att = row.DataBoundItem as Attendence;

                if (att != null)
                {
                    selectedAttendId = att.AttendID;
                    var present = attendControll.GetAttendenceById(selectedAttendId);

                    dateTimePicker.Text = present.Statusday;
                    AttStucomboBox.SelectedValue = present.StudentID;
                    AttSubcomboBox.SelectedValue = present.SubID;
                    AttStacomboBox.SelectedValue = present.StatusID;
                }
            }
            else
            {
                ClearForm();
            }
        }

        private void AttendenceForm_Load(object sender, EventArgs e)
        {

        }

        private void AttenddataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AttStucomboBox.Text) || string.IsNullOrWhiteSpace(AttSubcomboBox.Text))
            {
                MessageBox.Show("Please enter both Student and Subject.");
                return;
            }

            if (AttStacomboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid Status.");
                return;
            }

            var attend = new Attendence
            {
                Statusday = dateTimePicker.Text,
                StatusID = Convert.ToInt32(AttStacomboBox.SelectedValue),
                SubID = Convert.ToInt32(AttSubcomboBox.SelectedValue),
                StudentID = Convert.ToInt32(AttStucomboBox.SelectedValue)
            };

            attendControll.AddAttend(attend);
            LoadAttendtables();
            ClearForm();
            MessageBox.Show("Attendence Added Successfully");
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedAttendId == -1)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            if (AttStacomboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid Status.");
                return;
            }

            var att = new Attendence
            {
                AttendID = selectedAttendId,
                Statusday = dateTimePicker.Text,
                StatusID = Convert.ToInt32(AttStacomboBox.SelectedValue),
                SubID = Convert.ToInt32(AttSubcomboBox.SelectedValue),
                StudentID = Convert.ToInt32(AttStucomboBox.SelectedValue)
            };
        

            attendControll.UpdateAttend(att);
            LoadAttendtables();
            ClearForm();
            MessageBox.Show("Attendence Updated Successfully");
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (selectedAttendId == -1)
            {
                MessageBox.Show("Please select a Attendence to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                attendControll.DeleteAttend(selectedAttendId);
                LoadAttendtables();
                ClearForm();
                MessageBox.Show("Deleted Successfully");
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string studentName = AttStucomboBox.Text?.Trim();

            if (!string.IsNullOrEmpty(studentName))
            {
                var result = attendControll.SearchAttendenceByStudentName(studentName);

                if (result != null)
                {
                    selectedAttendId = result.AttendID;
                    dateTimePicker.Text = result.Statusday;
                    AttStucomboBox.SelectedValue = result.StudentID;
                    AttSubcomboBox.SelectedValue = result.SubID;
                    AttStacomboBox.SelectedValue = result.StatusID;
                }
                else
                {
                    MessageBox.Show("No attendance record found for that student.");
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Please enter or select a student name to search.");
            }
        }
    }
}
