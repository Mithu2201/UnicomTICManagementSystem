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
    public partial class ExamForm : Form
    {
        private readonly ExamController examController;
        private readonly SubjectControllers subjectController;
        private int selectedExamId = -1;

        public ExamForm()
        {
            InitializeComponent();
            examController = new ExamController();
            subjectController = new SubjectControllers();
            

            ExamdataGridView.SelectionChanged += ExamdataGridView_SelectionChanged;
            this.Load += ExamForm_Load;


        }

        private void LoadSubjects()
        {
            var subjects = subjectController.GetAllSubject();
            ExamcomboBox.DataSource = subjects;
            ExamcomboBox.DisplayMember = "Subname";
            ExamcomboBox.ValueMember = "SubID";
        }

        private void LoadExams()
        {
            ExamdataGridView.DataSource = null;
            ExamdataGridView.DataSource = examController.GetAllExams();

            if (ExamdataGridView.Columns.Contains("SubID"))
                ExamdataGridView.Columns["SubID"].Visible = false;

            ExamdataGridView.ClearSelection();
        }

        private void ClearForm()
        {
            ExcomboBox.SelectedIndex = -1;
            TypecomboBox.SelectedIndex = -1;
            ExamcomboBox.SelectedIndex = -1;
            selectedExamId = -1;
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            LoadExamComboBoxes();
            LoadSubjects();
            LoadExams();
        }


        private void Sadd_Click(object sender, EventArgs e)
        {
            if (ExcomboBox.SelectedItem == null || TypecomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please enter both Exam Name and Type.");
                return;
            }

            if (ExamcomboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a subject.");
                return;
            }

            var exam = new Exam
            {
                Exname = ExcomboBox.SelectedItem.ToString(),
                Exmode = TypecomboBox.SelectedItem.ToString(),
                SubID = (int)ExamcomboBox.SelectedValue
            };

            examController.AddExam(exam);
            LoadExams();
            ClearForm();
            MessageBox.Show("Exam added successfully.");
        }

        private void Sedit_Click(object sender, EventArgs e)
        {
            if (selectedExamId == -1)
            {
                MessageBox.Show("Please select an exam to edit.");
                return;
            }

            var exam = new Exam
            {
                ExID = selectedExamId,
                Exname = ExcomboBox.Text?.Trim(),
                Exmode = TypecomboBox.Text?.Trim(),
                SubID = (int)ExamcomboBox.SelectedValue
            };

            examController.UpdateExam(exam);
            LoadExams();
            ClearForm();
            MessageBox.Show("Exam updated successfully.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void Sdelete_Click(object sender, EventArgs e)
        {
            if (selectedExamId == -1)
            {
                MessageBox.Show("Please select an exam to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure to delete this exam?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                examController.DeleteExam(selectedExamId);
                LoadExams();
                ClearForm();
                MessageBox.Show("Exam deleted.");
            }
        }

        private void Ssearch_Click(object sender, EventArgs e)
        {
            string subjectName = ExamcomboBox.Text?.Trim();

            if (!string.IsNullOrEmpty(subjectName))
            {
                Exam foundExam = examController.SearchExamBySubjectName(subjectName);

                if (foundExam != null)
                {
                    selectedExamId = foundExam.ExID;
                    ExcomboBox.Text = foundExam.Exname;
                    TypecomboBox.Text = foundExam.Exmode;
                    ExamcomboBox.SelectedValue = foundExam.SubID;
                }
                else
                {
                    MessageBox.Show("No exam found for that subject.");
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Please enter or select a subject to search.");
            }
        }


        private void ExamdataGridView_SelectionChanged(object sender, EventArgs e)
        {

            if (ExamdataGridView.SelectedRows.Count > 0)
            {
                var row = ExamdataGridView.SelectedRows[0];
                var Exs = row.DataBoundItem as Exam;

                if (Exs != null)
                {
                    selectedExamId = Exs.ExID;

                    var selected = examController.GetExamById(selectedExamId);
                    if (selected != null)
                    {
                        
                        ExcomboBox.Text = selected.Exname;
                        TypecomboBox.Text = selected.Exmode;

                        
                        if (selected.SubID != 0)
                        {
                            ExamcomboBox.SelectedValue = selected.SubID;
                        }
                    }
                }
            }
            else
            {
                ClearForm();
            }
        }
        private void ExdataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void LoadExamComboBoxes()
        {
            var controller = new AddExamController();
            var examList = controller.GetExamNamesAndTypes();

            ExcomboBox.Items.Clear();
            TypecomboBox.Items.Clear();

            foreach (var ex in examList)
            {
                if (!ExcomboBox.Items.Contains(ex.AddExamCode))
                    ExcomboBox.Items.Add(ex.AddExamCode);

                if (!TypecomboBox.Items.Contains(ex.AddExamName))
                    TypecomboBox.Items.Add(ex.AddExamName);
            }
        }
    }
}
