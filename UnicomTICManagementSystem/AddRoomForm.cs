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

namespace UnicomTICManagementSystem
{
    public partial class AddRoomForm : Form
    {
        private int selectedRoomId = -1;
        public AddRoomForm()
        {
            InitializeComponent();
            this.Load += AddRoomForm_Load;
            RodataGridView.CellClick += RodataGridView_CellContentClick;
        }

        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void RodataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && RodataGridView.Rows[e.RowIndex].Cells["RoId"].Value != null)
            {
                DataGridViewRow selectedRow = RodataGridView.Rows[e.RowIndex];
                selectedRoomId = Convert.ToInt32(selectedRow.Cells["RoId"].Value);
                Rocode.Text = selectedRow.Cells["RoName"].Value.ToString();
                Roname.Text = selectedRow.Cells["RoType"].Value.ToString();
            }
        }

        private void LoadDataIntoGrid()
        {
            using (var conn = new SQLiteConnection("Data Source=Unicomtic.db;Version=3;"))
            {
                conn.Open();
                var adapter = new SQLiteDataAdapter("SELECT * FROM AddRooms", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                RodataGridView.DataSource = dt;
            }
        }

        private void ClearInputFields()
        {
            Rocode.Clear();
            Roname.Clear();
            selectedRoomId = -1;
        }

        private void Sadd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Rocode.Text) || string.IsNullOrWhiteSpace(Roname.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddRoomController controller = new AddRoomController();
            controller.InsertRoom(Rocode.Text, Roname.Text);
            LoadDataIntoGrid();
            ClearInputFields();
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedRoomId != -1)
            {
                AddRoomController controller = new AddRoomController();
                controller.UpdateRoom(selectedRoomId, Rocode.Text, Roname.Text);
                LoadDataIntoGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a room to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (RodataGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(RodataGridView.SelectedRows[0].Cells["RoId"].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this room?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    AddRoomController controller = new AddRoomController();
                    controller.DeleteRoom(id);
                    LoadDataIntoGrid();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a room to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string searchCode = Rocode.Text.Trim();  // Get input from Rocode.Text (Room Name)

            using (var conn = Dbconfig.GetConnection())
            {
                
                var cmd = new SQLiteCommand("SELECT * FROM AddRooms WHERE RoName = @RoName LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@RoName", searchCode);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        selectedRoomId = Convert.ToInt32(reader["RoId"]);
                        Rocode.Text = reader["RoName"].ToString(); // Room Name
                        Roname.Text = reader["RoType"].ToString(); // Room Type
                    }
                    else
                    {
                        MessageBox.Show("Room not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }
    }
}
