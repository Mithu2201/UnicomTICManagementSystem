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
    public partial class ClassForm : Form
    {
        private readonly ClassControllers classController;
        private readonly SubjectControllers subjectController;
        private int selectedClassId = -1;
        public ClassForm()
        {
            InitializeComponent();
            classController = new ClassControllers();
            subjectController = new SubjectControllers();

            CldataGridView.SelectionChanged += CldataGridView_SelectionChanged;
            this.Load += ClassForm_Load;
            
        }

        private void ClassForm_Load(object sender, EventArgs e)
        {
            LoadClassComboBoxes();
            LoadClasses();
            LoadSubjects();
            ClcomboBox.SelectedIndex = -1;

        }

        private void LoadClasses()
        {
            CldataGridView.DataSource = null;
            CldataGridView.DataSource = classController.GetAllClasses();

            if (CldataGridView.Columns.Contains("SubID"))
                CldataGridView.Columns["SubID"].Visible = false;

            CldataGridView.ClearSelection();
        }

        private void LoadSubjects()
        {
            var subjects = subjectController.GetAllSubject();
            ClcomboBox.DataSource = subjects;
            ClcomboBox.DisplayMember = "Subname";
            ClcomboBox.ValueMember = "SubID";
        }

        private void ClearForm()
        {
            ClcomboBox.SelectedIndex = -1;
            ClModecomboBox.SelectedIndex = -1;
            ClNamecomboBox.SelectedIndex = -1;

            ClcomboBox.Text = "";
            ClModecomboBox.Text = "";
            ClNamecomboBox.Text = "";
            selectedClassId = -1;
        }

        private void CldataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (CldataGridView.SelectedRows.Count > 0)
            {
                var row = CldataGridView.SelectedRows[0];
                var cls = row.DataBoundItem as Class;

                if (cls != null)
                {
                    selectedClassId = cls.ClID;

                    var selected = classController.GetClassById(selectedClassId);
                    if (selected != null)
                    {
                        // Update ComboBoxes instead of TextBoxes
                        ClNamecomboBox.Text = selected.Clname;
                        ClModecomboBox.Text = selected.Clmode;

                        // Subject selection using SubID
                        if (selected.SubID != 0)
                        {
                            ClcomboBox.SelectedValue = selected.SubID;
                        }
                    }
                }
            }
        }

        private void Sadd_Click(object sender, EventArgs e)
        {
            if (ClNamecomboBox.SelectedItem == null || ClModecomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select both Class Name and Mode.");
                return;
            }

            if (ClcomboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a Subject.");
                return;
            }

            var cls = new Class
            {
                Clname = ClNamecomboBox.SelectedItem.ToString(),
                Clmode = ClModecomboBox.SelectedItem.ToString(),
                SubID = (int)ClcomboBox.SelectedValue
            };

            classController.AddClass(cls);
            LoadClasses();
            ClearForm();
            MessageBox.Show("Class added successfully.");
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ClNamecomboBox.Text) || string.IsNullOrWhiteSpace(ClModecomboBox.Text))
            {
                MessageBox.Show("Please enter or select both Class Name and Mode.");
                return;
            }

            var cls = new Class
            {
                ClID = selectedClassId,
                Clname = ClNamecomboBox.Text?.Trim(),  
                Clmode = ClModecomboBox.Text?.Trim(),
                SubID = (int)ClcomboBox.SelectedValue
            };

            classController.UpdateClass(cls);
            LoadClasses();
            ClearForm();
            MessageBox.Show("Class updated successfully.");
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (selectedClassId == -1)
            {
                MessageBox.Show("Please select a class to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this class?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                classController.DeleteClass(selectedClassId);
                LoadClasses();
                ClearForm();
                MessageBox.Show("Class deleted successfully.");
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string subjectName = ClcomboBox.Text?.Trim();

            if (!string.IsNullOrEmpty(subjectName))
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    string query = @"
                                    SELECT c.ClassId, c.ClassName, c.ClassMode, c.SubjectID, s.SubjectName
                                    FROM Classes c
                                    JOIN Subjects s ON c.SubjectID = s.SubjectId
                                    WHERE s.SubjectName LIKE @SubName
                                    LIMIT 1";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubName", $"%{subjectName}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedClassId = Convert.ToInt32(reader["ClassId"]);
                                ClNamecomboBox.Text = reader["ClassName"].ToString();
                                ClModecomboBox.Text = reader["ClassMode"].ToString();
                                ClcomboBox.SelectedValue = Convert.ToInt32(reader["SubjectID"]);
                            }
                            else
                            {
                                MessageBox.Show("Class not found for that subject.");
                                ClearForm();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select or enter a subject name to search.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadClassComboBoxes()
        {
            var controller = new AddClassController();
            var classList = controller.GetClassNamesAndModes();

            ClNamecomboBox.Items.Clear();
            ClModecomboBox.Items.Clear();

            foreach (var c in classList)
            {
                if (!ClNamecomboBox.Items.Contains(c.AddClassCode))
                    ClNamecomboBox.Items.Add(c.AddClassCode);

                if (!ClModecomboBox.Items.Contains(c.AddClassName))
                    ClModecomboBox.Items.Add(c.AddClassName);
            }
        }
    }
}
