using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class StudentCourseController
    {
        public void AssignCourseToStudent(StudentCourse sc)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO StudentCourses (StudentId, CourseId)
                                    VALUES (@studentId, @courseId)";
                cmd.Parameters.AddWithValue("@studentId", sc.StudentId);
                cmd.Parameters.AddWithValue("@courseId", sc.CourseId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Course> GetCoursesByStudent(int studentId)
        {
            var courses = new List<Course>();

            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT c.CouId, c.CouCode, c.CouName
                    FROM Courses c
                    INNER JOIN StudentCourses sc ON c.CouId = sc.CourseId
                    WHERE sc.StudentId = @studentId";
                cmd.Parameters.AddWithValue("@studentId", studentId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseID = reader.GetInt32(0),
                            CourseCode = reader.GetString(1),
                            CourseName = reader.GetString(2)
                        });
                    }
                }
            }

            return courses;
        }

        public void UpdateStudentCourse(StudentCourse sc)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE StudentCourses SET StudentId = @sid, CourseId = @cid WHERE SCId = @scid";
                cmd.Parameters.AddWithValue("@sid", sc.StudentId);
                cmd.Parameters.AddWithValue("@cid", sc.CourseId);
                cmd.Parameters.AddWithValue("@scid", sc.SCId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudentCourse(int scId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentCourses WHERE SCId = @id";
                cmd.Parameters.AddWithValue("@id", scId);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetCoursesByStudentDataTable(int studentId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            SELECT sc.SCId, s.StdName, c.CouName
            FROM StudentCourses sc
            JOIN Students s ON sc.StudentId = s.StdId
            JOIN Courses c ON sc.CourseId = c.CouId
            WHERE sc.StudentId = @sid";
                cmd.Parameters.AddWithValue("@sid", studentId);

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT StdId, StdName FROM Students", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Std_ID = reader.GetInt32(0),
                            Std_Name = reader.GetString(1)
                        });
                    }
                }
            }
            return students;
        }

        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT CouId, CouName FROM Courses", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseID = reader.GetInt32(0),
                            CourseName = reader.GetString(1)
                        });
                    }
                }
            }
            return courses;
        }

        public DataTable GetAllStudentCourseDataTable()
        {
            var dt = new DataTable();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
            SELECT sc.SCId, s.StdName, c.CouName 
            FROM StudentCourses sc
            JOIN Students s ON sc.StudentId = s.StdId
            JOIN Courses c ON sc.CourseId = c.CouId", conn);
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }
    }
}
