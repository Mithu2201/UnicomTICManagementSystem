using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem
{
    public partial class LectureForm : Form
    {
        private int selectedLectureId = -1;
        public LectureForm()
        {
            InitializeComponent();
            this.Load += LectureForm_Load;
            LecdataGridView.CellClick += LecdataGridView_CellContentClick;
        }

        private void LectureForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LecdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && LecdataGridView.Rows[e.RowIndex].Cells["LecId"].Value != null)
            {
                DataGridViewRow selectedRow = LecdataGridView.Rows[e.RowIndex];

                selectedLectureId = Convert.ToInt32(selectedRow.Cells["LecId"].Value);
                Lecname.Text = selectedRow.Cells["LecName"].Value.ToString();
                LecPhone.Text = selectedRow.Cells["LecPhone"].Value.ToString();
                LecAddress.Text = selectedRow.Cells["LecAddress"].Value.ToString();

            }
        }

        private void ClearInputFields()
        {
            Lecname.Clear();
            LecPhone.Clear();
            LecAddress.Clear();

        }

        private void LoadDataIntoGrid()
        {
            string query = "SELECT * FROM Lectures";

            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    LecdataGridView.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedLectureId != -1)
            {
                string updatedName = Lecname.Text;
                string updatedPhone = LecPhone.Text;
                string updatedAddress = LecAddress.Text;

                // Get userId from the currently selected row (or from a hidden field)
                int userId = -1;
                if (LecdataGridView.CurrentRow != null)
                {
                    userId = Convert.ToInt32(LecdataGridView.CurrentRow.Cells["UserId"].Value);
                }

                LectureControllers controller = new LectureControllers();
                controller.UpdateLecture(selectedLectureId, updatedName, updatedPhone, updatedAddress, userId);

                LoadDataIntoGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a Lecture from the grid to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       

        

        private void Ssearch_Click_1(object sender, EventArgs e)
        {
            string searchName = Lecname.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                LectureControllers controller = new LectureControllers();
                Lectures lecture = controller.SearchLectureByName(searchName);

                if (lecture != null)
                {
                    selectedLectureId = lecture.Lec_ID;
                    Lecname.Text = lecture.Lec_Name;
                    LecPhone.Text = lecture.Lec_Phone;
                    LecAddress.Text = lecture.Lec_Address;
                    
                }
                else
                {
                    MessageBox.Show("Lecture not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    selectedLectureId = -1;
                }
            }
            else
            {
                MessageBox.Show("Please enter a lecture name to search.", "Input Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Sdelete_Click_1(object sender, EventArgs e)
        {
            if (LecdataGridView.SelectedRows.Count > 0)
            {
                
                int selectedId = Convert.ToInt32(LecdataGridView.SelectedRows[0].Cells["LecId"].Value);

                
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this lecture?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    LectureControllers controller = new LectureControllers();
                    controller.DeleteLecture(selectedId);

                    
                    LoadDataIntoGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a Lecture to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
