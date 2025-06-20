using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class AddExamController
    {
        public void InsertExam(string code, string name)
        {
            string insertQuery = "INSERT INTO AddExams (ExName, ExType) VALUES (@ExName, @ExType)";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ExName", code);
                    cmd.Parameters.AddWithValue("@ExType", name);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Exam inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void DeleteExam(int id)
        {
            string deleteQuery = "DELETE FROM AddExams WHERE ExId = @ExId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ExId", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Exam deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Exam not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void UpdateExam(int id, string code, string name)
        {
            string updateQuery = "UPDATE AddExams SET ExName = @ExName, ExType = @ExType WHERE ExId = @ExId";

            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ExId", id);
                    cmd.Parameters.AddWithValue("@ExName", code);
                    cmd.Parameters.AddWithValue("@ExType", name);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Exam updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Exam not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public List<AddExam> GetAllExams()
        {
            var exams = new List<AddExam>();

            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM AddExams", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    exams.Add(new AddExam
                    {
                        AddExamID = reader.GetInt32(0),
                        AddExamCode = reader.GetString(1),
                        AddExamName = reader.GetString(2)
                    });
                }
            }

            return exams;
        }

        public List<AddExam> GetExamNamesAndTypes()
        {
            var examList = new List<AddExam>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT ExName, ExType FROM AddExams", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    examList.Add(new AddExam
                    {
                        AddExamCode = reader.GetString(0), // ExName
                        AddExamName = reader.GetString(1)  // ExType
                    });
                }
            }
            return examList;
        }
    }
}
