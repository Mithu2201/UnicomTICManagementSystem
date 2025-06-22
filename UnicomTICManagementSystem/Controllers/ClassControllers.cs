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
    internal class ClassControllers
    {
        public void AddClass(Class cls)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Classes (ClassName, ClassMode, SubjectID) VALUES (@ClassName, @ClassMode, @SubjectID)", conn);
                cmd.Parameters.AddWithValue("@ClassName", cls.Clname);
                cmd.Parameters.AddWithValue("@ClassMode", cls.Clmode);
                cmd.Parameters.AddWithValue("@SubjectID", cls.SubID);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateClass(Class cls)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Classes SET ClassName = @ClassName, ClassMode = @ClassMode, SubjectID = @SubjectID WHERE ClassId = @ClassId", conn);
                cmd.Parameters.AddWithValue("@ClassId", cls.ClID);
                cmd.Parameters.AddWithValue("@ClassName", cls.Clname);
                cmd.Parameters.AddWithValue("@ClassMode", cls.Clmode);
                cmd.Parameters.AddWithValue("@SubjectID", cls.SubID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClass(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Classes WHERE ClassId = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Class SearchClassBySubjectName(string subjectName)
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
                            return new Class
                            {
                                ClID = Convert.ToInt32(reader["ClassId"]),
                                Clname = reader["ClassName"].ToString(),
                                Clmode = reader["ClassMode"].ToString(),
                                SubID = Convert.ToInt32(reader["SubjectID"]),
                                Subname = reader["SubjectName"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Class> GetAllClasses()
        {
            var classList = new List<Class>();

            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    SELECT c.ClassId, c.ClassName, c.ClassMode, c.SubjectID, s.SubjectName
                    FROM Classes c
                    LEFT JOIN Subjects s ON c.SubjectID = s.SubjectId", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cls = new Class
                    {
                        ClID = reader.GetInt32(0),
                        Clname = reader.GetString(1),
                        Clmode = reader.GetString(2),
                        SubID = reader.GetInt32(3),
                        Subname = reader.IsDBNull(4) ? "" : reader.GetString(4)
                    };
                    classList.Add(cls);
                }
            }

            return classList;
        }

        public Class GetClassById(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Classes WHERE ClassId = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Class
                        {
                            ClID = reader.GetInt32(0),
                            Clname = reader.GetString(1),
                            Clmode = reader.GetString(2),
                            SubID = reader.GetInt32(3)
                        };
                    }
                }
            }

            return null;
        }
    }

}
