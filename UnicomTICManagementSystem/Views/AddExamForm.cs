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
using System.Xml.Linq;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem
{
    public partial class AddExamForm : Form
    {
        private int selectedExamId = -1;
        public AddExamForm()
        {
            InitializeComponent();
            this.Load += AddExamForm_Load;
            ExdataGridView.CellClick += TidataGridView_CellContentClick;
        }

        private void AddExamForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void ClearInputFields()
        {
            ExType.Clear();
            Exname.Clear();
        }

        private void TidataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ExdataGridView.Rows[e.RowIndex].Cells["ExId"].Value != null)
            {
                DataGridViewRow selectedRow = ExdataGridView.Rows[e.RowIndex];
                selectedExamId = Convert.ToInt32(selectedRow.Cells["ExId"].Value);
                ExType.Text = selectedRow.Cells["ExName"].Value.ToString();
                Exname.Text = selectedRow.Cells["ExType"].Value.ToString();
            }
        }

        private void LoadDataIntoGrid()
        {
            string query = "SELECT * FROM AddExams";

            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ExdataGridView.DataSource = dt;
                }
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchName = Exname.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                var controller = new AddExamController();
                var result = controller.SearchExamByName(searchName);

                if (result != null)
                {
                    selectedExamId = result.AddExamID;
                    Exname.Text = result.AddExamCode;
                    ExType.Text = result.AddExamName;
                }
                else
                {
                    MessageBox.Show("Exam not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    selectedExamId = -1;
                }
            }
            else
            {
                MessageBox.Show("Please enter an exam name to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Exname.Text) || string.IsNullOrEmpty(ExType.Text))
            {
                MessageBox.Show("Both Class Code and Class Name are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddExam exam = new AddExam
            {
                AddExamCode = Exname.Text,
                AddExamName = ExType.Text
            };

            AddExamController controller = new AddExamController();
            controller.InsertExam(exam.AddExamCode, exam.AddExamName);

            LoadDataIntoGrid();
            ClearInputFields();
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedExamId != -1)
            {
                string updatedCode = Exname.Text;
                string updatedName = ExType.Text;

                AddExamController controller = new AddExamController();
                controller.UpdateExam(selectedExamId, updatedCode, updatedName);

                LoadDataIntoGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select an exam to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (ExdataGridView.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(ExdataGridView.SelectedRows[0].Cells["ExId"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this Exam?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    AddExamController controller = new AddExamController();
                    controller.DeleteExam(selectedId);

                    LoadDataIntoGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please select an Exam to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
