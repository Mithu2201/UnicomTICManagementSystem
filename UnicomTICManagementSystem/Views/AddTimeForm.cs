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
    public partial class AddTimeForm : Form
    {
        private int selectedTimeId = -1;
        public AddTimeForm()
        {
            InitializeComponent();
            this.Load += AddTimeForm_Load;
            TidataGridView.CellClick += TidataGridView_CellContentClick;
        }

        private void AddTimeForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                string query = "SELECT * FROM AddTimes";
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    TidataGridView.DataSource = dt;
                }
            }
        }

        private void ClearFields()
        {
            
            TiSlot.Clear();
        }

        private void TidataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && TidataGridView.Rows[e.RowIndex].Cells["TiId"].Value != null)
            {
                var row = TidataGridView.Rows[e.RowIndex];
                selectedTimeId = Convert.ToInt32(row.Cells["TiId"].Value);
                TidateTimePicker.Text = row.Cells["TiDay"].Value.ToString();
                TiSlot.Text = row.Cells["TiSlot"].Value.ToString();
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchDay = TidateTimePicker.Text.Trim();

            if (!string.IsNullOrEmpty(searchDay))
            {
                var controller = new AddTimeController();
                var result = controller.SearchAddTimeByDay(searchDay);

                if (result != null)
                {
                    selectedTimeId = result.AddTimeID;
                    TidateTimePicker.Text = result.AddTimeCode;
                    TiSlot.Text = result.AddTimeName;
                }
                else
                {
                    MessageBox.Show("Time not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    selectedTimeId = -1;
                }
            }
            else
            {
                MessageBox.Show("Please enter a day to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TidateTimePicker.Text) || string.IsNullOrWhiteSpace(TiSlot.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddTime at = new AddTime
            {
                AddTimeCode = TidateTimePicker.Text,
                AddTimeName = TiSlot.Text
            };
            new AddTimeController().InsertAddTime(at.AddTimeCode, at.AddTimeName);
            LoadData();
            ClearFields();
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedTimeId != -1)
            {
                new AddTimeController().UpdateAddTime(selectedTimeId, TidateTimePicker.Text, TiSlot.Text);
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please select a time slot to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (TidataGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(TidataGridView.SelectedRows[0].Cells["TiId"].Value);
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    new AddTimeController().DeleteAddTime(id);
                    LoadData();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Select a time slot to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
