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
        private int selectedStudentId = -1;
        public RegistrationForm()
        {
            InitializeComponent();
            this.Load += StdForm_Load;
        }

        private void StdForm_Load(object sender, EventArgs e)
        {
        }


        private void ClearInputFields()
        {
            Stdname.Clear();
            StdPhone.Clear();
            StdAddress.Clear();
            StdUserName.Clear();
            StdUserPass.Clear();
            StdUserRole.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void Sadd_Click_1(object sender, EventArgs e)
        {

            // First, insert the user and get userId
            User user = new User
            {
                UserName = StdUserName.Text,
                PassAdd = StdUserPass.Text,
                Role = StdUserRole.Text
            };

            UserController userController = new UserController();
            int userId = userController.InsertUser(user.UserName, user.PassAdd, user.Role);

            // Now check the role and insert accordingly
            if (StdUserRole.Text == "Student")
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
            }
            else if (StdUserRole.Text == "Lecture")
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
            }
            else if (StdUserRole.Text == "Staff")
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
            }
            else
            {
                MessageBox.Show("Invalid role specified. Please enter Student, Lecture, or Staff.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearInputFields();


        }
        

    }
}
