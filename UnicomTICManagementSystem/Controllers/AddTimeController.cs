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
    internal class AddTimeController
    {
        public void InsertAddTime(string code, string slot)
        {
            string query = "INSERT INTO AddTimes (TiDay, TiSlot) VALUES (@TiDay, @TiSlot)";
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TiDay", code);
                    cmd.Parameters.AddWithValue("@TiSlot", slot);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Time inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void DeleteAddTime(int id)
        {
            string query = "DELETE FROM AddTimes WHERE TiId = @TiId";
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TiId", id);
                    int affected = cmd.ExecuteNonQuery();
                    MessageBox.Show(affected > 0 ? "Time deleted successfully!" : "Time not found.", "Result", MessageBoxButtons.OK, affected > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                }
            }
        }

        public void UpdateAddTime(int id, string code, string slot)
        {
            string query = "UPDATE AddTimes SET TiDay = @TiDay, TiSlot = @TiSlot WHERE TiId = @TiId";
            using (var conn = Dbconfig.GetConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TiId", id);
                    cmd.Parameters.AddWithValue("@TiDay", code);
                    cmd.Parameters.AddWithValue("@TiSlot", slot);

                    int affected = cmd.ExecuteNonQuery();
                    MessageBox.Show(affected > 0 ? "Time updated successfully!" : "Time not found.", "Result", MessageBoxButtons.OK, affected > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                }
            }
        }

        public AddTime SearchAddTimeByCode(string code)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                string query = "SELECT * FROM AddTimes WHERE AddTimeCode = @AddTimeCode";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AddTimeCode", code);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AddTime
                            {
                                AddTimeID = Convert.ToInt32(reader["AddTimeID"]),
                                AddTimeCode = reader["AddTimeCode"].ToString(),
                                AddTimeName = reader["AddTimeName"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }



        public List<AddTime> GetTimeDaysAndSlots()
        {
            var timeList = new List<AddTime>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT TiDay, TiSlot FROM AddTimes", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    timeList.Add(new AddTime
                    {
                        AddTimeCode = reader.GetString(0), 
                        AddTimeName = reader.GetString(1)  
                    });
                }
            }
            return timeList;
        }
    }
}
