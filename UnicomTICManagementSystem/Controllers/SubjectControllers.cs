using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class SubjectControllers
    {

        public void AddSubject(Subject Sub)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO Subjects (SubjectCode, SubjectName, CourseID) VALUES (@SubjectCode, @SubjectName, @CourseID)", conn);
                command.Parameters.AddWithValue("@SubjectCode", Sub.SubCode);
                command.Parameters.AddWithValue("@SubjectName", Sub.Subname);
                command.Parameters.AddWithValue("@CourseID", Sub.CourseID);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateSubject(Subject Sub)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var command = new SQLiteCommand("UPDATE Subjects SET SubjectCode = @SubjectCode, SubjectName = @SubjectName, CourseID = @CourseID WHERE  SubjectId = @SubjectId", conn);
                command.Parameters.AddWithValue("@SubjectId", Sub.SubID);
                command.Parameters.AddWithValue("@SubjectCode", Sub.SubCode);
                command.Parameters.AddWithValue("@SubjectName", Sub.Subname);
                command.Parameters.AddWithValue("@CourseID", Sub.CourseID);
               
                command.ExecuteNonQuery();
            }
        }

        public void DeleteSubject(int SubjectId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM Subjects WHERE SubjectId = @SubjectId", conn);
                command.Parameters.AddWithValue("@SubjectId", SubjectId);
                command.ExecuteNonQuery();
            }
        }

        public Subject GetsubjectById(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Subjects WHERE SubjectId = @SubID", conn);
                cmd.Parameters.AddWithValue("@SubID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Subject
                        {
                            SubID = reader.GetInt32(0),
                            SubCode = reader.GetString(1),
                            Subname = reader.GetString(2),
                            CourseID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                        };
                    }
                }
            }

            return null;
        }

        public List<Subject> GetAllSubject()
        {
            var Subjects = new List<Subject>();

            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
            SELECT s.SubjectId, s.SubjectCode, s.SubjectName, s.CourseId, c.CouName AS CourseName
            FROM Subjects s
            LEFT JOIN Courses c ON s.CourseId = c.CouId", conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Subject subj = new Subject
                    {
                        SubID = reader.GetInt32(0),
                        SubCode = reader.GetString(1),
                        Subname = reader.GetString(2),
                        CourseID = reader.GetInt32(3),
                        CourseName = reader.IsDBNull(4) ? "" : reader.GetString(4) 
                    };
                    Subjects.Add(subj);
                }
            }

            return Subjects;
        }

    }
}
