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
    public partial class RegistrationForm : Form
    {
        
        public RegistrationForm()
        {
            InitializeComponent();
            this.Load += StdForm_Load;
        }

        private void StdForm_Load(object sender, EventArgs e)
        {
            LoadRolesIntoComboBox();
        }


        private void ClearInputFields()
        {
            Stdname.Clear();
            StdPhone.Clear();
            StdAddress.Clear();
            StdUserName.Clear();
            StdUserPass.Clear();
            RegcomboBox.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void Sadd_Click_1(object sender, EventArgs e)
        {
            if (!ValidateRoleNumber())
            {
                return; // Stop the registration if validation fails
            }

            if (StdPhone.Text.Length != 10 || !StdPhone.Text.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must be exactly 10 digits and numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // First, insert the user and get userId
            User user = new User
            {
                UserName = StdUserName.Text,
                PassAdd = StdUserPass.Text,
                Role = RegcomboBox.Text
            };

            UserController userController = new UserController();
            int userId = userController.InsertUser(user.UserName, user.PassAdd, user.Role);

            if (userId == -1)
            {
                return; // Prevent further execution
            }

            // Now check the role and insert accordingly
            if (RegcomboBox.Text == "Student")
            {
                Student student = new Student
                {
                    Std_Name = Stdname.Text,
                    Std_Phone = StdPhone.Text,
                    Std_Address = StdAddress.Text,
                    User_ID = userId
                };

                StudentController studentController = new StudentController();
                studentController.InsertStudent(student.Std_Name, student.Std_Phone, student.Std_Address, student.User_ID);

                MessageBox.Show("Student inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
            }
            else if (RegcomboBox.Text == "Lecture")
            {
                Lectures lecture = new Lectures
                {
                    Lec_Name = Stdname.Text,
                    Lec_Phone = StdPhone.Text,
                    Lec_Address = StdAddress.Text,
                    User_ID = userId
                };

                LectureControllers lectureController = new LectureControllers();
                lectureController.InsertLecture(lecture.Lec_Name, lecture.Lec_Phone, lecture.Lec_Address, lecture.User_ID);

                MessageBox.Show("Lecture inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
            }
            else if (RegcomboBox.Text == "Staff")
            {
                Staffs staff = new Staffs
                {
                    Stf_Name = Stdname.Text,
                    Stf_Phone = StdPhone.Text,
                    Stf_Address = StdAddress.Text,
                    User_ID = userId
                };

                StaffControllers staffController = new StaffControllers();
                staffController.InsertStaff(staff.Stf_Name, staff.Stf_Phone, staff.Stf_Address, staff.User_ID);

                MessageBox.Show("Staff inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
            }
            else if (RegcomboBox.Text == "Admin")
            {
                Staffs staff = new Staffs
                {
                    Stf_Name = Stdname.Text,
                    Stf_Phone = StdPhone.Text,
                    Stf_Address = StdAddress.Text,
                    User_ID = userId
                };

                StaffControllers staffController = new StaffControllers();
                staffController.InsertStaff(staff.Stf_Name, staff.Stf_Phone, staff.Stf_Address, staff.User_ID);

                MessageBox.Show("New Admin inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid role specified. Please enter Student, Lecture, or Staff.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearInputFields();



        }

        private void LoadRolesIntoComboBox()
        {
            RoleController roleController = new RoleController();
            List<string> roleNames = roleController.GetAllRoleNames();

            RegcomboBox.DataSource = roleNames;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool ValidateRoleNumber()
        {
            string selectedRoleName = RegcomboBox.Text.Trim();
            string enteredRoleCode = RegRole.Text.Trim();

            if (string.IsNullOrWhiteSpace(selectedRoleName) || string.IsNullOrWhiteSpace(enteredRoleCode))
            {
                MessageBox.Show("Please enter both Role Number and select a Role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT 1 FROM Roles WHERE RoleName = @RoleName AND RoleCode = @RoleCode LIMIT 1";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleName", selectedRoleName);
                    cmd.Parameters.AddWithValue("@RoleCode", enteredRoleCode);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Invalid Role Number for the selected Role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
