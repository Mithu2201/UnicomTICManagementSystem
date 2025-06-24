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
    public partial class RoomForm : Form
    {
        private readonly RoomController roomController;
        private readonly ExamController examController;
        private readonly ClassControllers classController;
        private readonly AddRoomController addRoomController = new AddRoomController();

        private int selectedRoomId = -1;
        public RoomForm()
        {
            InitializeComponent();
            roomController = new RoomController();
            classController = new ClassControllers();
            examController = new ExamController(); 
            RoomdataGridView.SelectionChanged += RoomdataGridView_SelectionChanged;

            this.Load += RoomForm_Load;
            LoadRooms();
            LoadExams();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            LoadRoomComboBoxes();
            StucomboBox.Items.Add("Class");
            StucomboBox.Items.Add("Exam");
            StucomboBox.SelectedIndexChanged += StucomboBox_SelectedIndexChanged;
        }

        private void StucomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StucomboBox.SelectedItem == null) return;

            string selectedMode = StucomboBox.SelectedItem.ToString();

            if (selectedMode == "Class")
            {
                var classList = classController.GetAllClasses();
                RoomcomboBox.DataSource = classList;
                RoomcomboBox.DisplayMember = "Clname";   
                RoomcomboBox.ValueMember = "ClID";       
            }
            else if (selectedMode == "Exam")
            {
                var examList = examController.GetAllExams();
                RoomcomboBox.DataSource = examList;
                RoomcomboBox.DisplayMember = "Exname";   
                RoomcomboBox.ValueMember = "ExID";       
            }
        }

        private void LoadRooms()
        {
            RoomdataGridView.DataSource = null;
            RoomdataGridView.DataSource = roomController.GetAllRooms();
            if (RoomdataGridView.Columns.Contains("ExID"))
                RoomdataGridView.Columns["ExID"].Visible = false;

            RoomdataGridView.ClearSelection();
        }

        private void LoadExams()
        {
            var exams = examController.GetAllExams();
            RoomcomboBox.DataSource = exams;
            RoomcomboBox.DisplayMember = "ExName";
            RoomcomboBox.ValueMember = "ExID";
        }

        private void ClearForm()
        {
            RoRoomcomboBox.SelectedIndex = -1;
            RoTypecomboBox.SelectedIndex = -1;
            RoomcomboBox.SelectedIndex = -1;
            selectedRoomId = -1;
        }

        private void RoomdataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (RoomdataGridView.SelectedRows.Count > 0)
            {
                var row = RoomdataGridView.SelectedRows[0];
                var room = row.DataBoundItem as Room;

                if (room != null)
                {
                    selectedRoomId = room.RoID;
                    var fullRoom = roomController.GetRoomById(selectedRoomId);
                    if (fullRoom != null)
                    {
                        RoRoomcomboBox.Text = fullRoom.Roname;
                        RoTypecomboBox.Text = fullRoom.Rotype;
                        RoomcomboBox.SelectedValue = fullRoom.ExID;
                    }
                }
            }
            else
            {
                ClearForm();
            }
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoRoomcomboBox.Text) || string.IsNullOrWhiteSpace(RoTypecomboBox.Text))
            {
                MessageBox.Show("Please enter both Room Name and Room Type.");
                return;
            }

            if (StucomboBox.SelectedItem == null || RoomcomboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select Study Mode and a session.");
                return;
            }

            string studyMode = StucomboBox.SelectedItem.ToString();

            var room = new Room
            {
                Roname = RoRoomcomboBox.Text.Trim(),
                Rotype = RoTypecomboBox.Text.Trim(),
                StudyMode = studyMode,
                ExID = (studyMode == "Exam") ? (int?)RoomcomboBox.SelectedValue : null,
                ClID = (studyMode == "Class") ? (int?)RoomcomboBox.SelectedValue : null
            };

            roomController.AddRoom(room);
            LoadRooms();
            ClearForm();
            MessageBox.Show("Room Added Successfully");
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == -1)
            {
                MessageBox.Show("Please select a room to update.");
                return;
            }

            var room = new Room
            {
                RoID = selectedRoomId,
                Roname = RoRoomcomboBox.Text,
                Rotype = RoTypecomboBox.Text,
                ExID = (int)RoomcomboBox.SelectedValue
            };

            roomController.UpdateRoom(room);
            LoadRooms();
            ClearForm();
            MessageBox.Show("Room Updated Successfully");
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == -1)
            {
                MessageBox.Show("Please select a room to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this room?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                roomController.DeleteRoom(selectedRoomId);
                LoadRooms();
                ClearForm();
                MessageBox.Show("Room Deleted Successfully");
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchName = RoRoomcomboBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                var room = roomController.SearchRoomByName(searchName);
                if (room != null)
                {
                    selectedRoomId = room.RoID;
                    RoRoomcomboBox.Text = room.Roname;
                    RoTypecomboBox.Text = room.Rotype;

                    
                    if (room.ClID.HasValue)
                    {
                        StucomboBox.SelectedItem = "Class";
                        RoomcomboBox.SelectedValue = room.ClID.Value;
                    }
                    else if (room.ExID.HasValue)
                    {
                        StucomboBox.SelectedItem = "Exam";
                        RoomcomboBox.SelectedValue = room.ExID.Value;
                    }
                    else
                    {
                        RoomcomboBox.SelectedIndex = -1;
                    }
                }
                else
                {
                    MessageBox.Show("Room not found.");
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Enter room name to search.");
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadRoomComboBoxes()
        {
            var rooms = addRoomController.GetRoomNamesAndTypes();

            RoRoomcomboBox.Items.Clear();
            RoTypecomboBox.Items.Clear();

            foreach (var room in rooms)
            {
                if (!RoRoomcomboBox.Items.Contains(room.AddRoomCode))
                    RoRoomcomboBox.Items.Add(room.AddRoomCode);

                if (!RoTypecomboBox.Items.Contains(room.AddRoomName))
                    RoTypecomboBox.Items.Add(room.AddRoomName);
            }
        }

        private void RoomdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
