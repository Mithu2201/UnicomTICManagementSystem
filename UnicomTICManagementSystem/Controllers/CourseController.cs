﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;
using static System.Collections.Specialized.BitVector32;

namespace UnicomTICManagementSystem.Controllers
{
    internal class CourseController
    {
        public void InsertCourse(string code, string name)
        {
            string insertQuery = "INSERT INTO Courses (CouCode, CouName) " +
                "VALUES (@CouCode, @CouName)";

            using (var conn = Dbconfig.GetConnection())
            {

                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CouCode", code);
                    cmd.Parameters.AddWithValue("@CouName", name);
                    

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        public void DeleteCourse(int id)
        {
            string deleteQuery = "DELETE FROM Courses WHERE CouId = @CouId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CouId", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Course not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void UpdateCourse(int courseid, string code, string name)
        {
            string updateQuery = "UPDATE Courses SET CouCode = @CouCode, CouName = @CouName WHERE CouId = @CouId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CouId", courseid);
                    cmd.Parameters.AddWithValue("@CouCode", code);
                    cmd.Parameters.AddWithValue("@CouName", name);
                    

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Course not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public Course SearchCourseByCode(string code)
        {
            string query = "SELECT * FROM Courses WHERE CouCode = @CouCode LIMIT 1";

            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CouCode", code);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Course
                        {
                            CourseID = Convert.ToInt32(reader["CouId"]),
                            CourseCode = reader["CouCode"].ToString(),
                            CourseName = reader["CouName"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public List<Course> GetAllCourse()
        {
            var Courses = new List<Course>();

            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Courses", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Courses.Add(new Course
                    {
                        CourseID = reader.GetInt32(0),
                        CourseCode = reader.GetString(1),
                        CourseName = reader.GetString(2)
                    });
                }
            }

            return Courses;
        }
    }
}
