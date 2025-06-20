﻿using System;
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
    internal class AddClassController
    {
        public void InsertClass(string name, string code)
        {
            string insertQuery = "INSERT INTO AddClasses (ClName, ClMode) VALUES (@ClName, @ClMode)";
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ClName", name);   // Clname.Text (Topic Name)
                cmd.Parameters.AddWithValue("@ClMode", code);   // Clcode.Text (Study Mode)
                cmd.ExecuteNonQuery();
                MessageBox.Show("Class inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void UpdateClass(int id, string name, string code)
        {
            string updateQuery = "UPDATE AddClasses SET ClName = @ClName, ClMode = @ClMode WHERE ClId = @ClId";
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ClId", id);
                cmd.Parameters.AddWithValue("@ClName", name);   // Clname.Text
                cmd.Parameters.AddWithValue("@ClMode", code);   // Clcode.Text
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    MessageBox.Show("Class updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Class not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteClass(int id)
        {
            string deleteQuery = "DELETE FROM AddClasses WHERE ClId = @ClId";

            using (var conn = Dbconfig.GetConnection())
            using (var cmd = new SQLiteCommand(deleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ClId", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Class deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Class not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //public List<AddClass> GetAllClasses()
        //{
        //    var classes = new List<AddClass>();
        //    using (var conn = Dbconfig.GetConnection())
        //    {
        //        var cmd = new SQLiteCommand("SELECT * FROM AddClasses", conn);
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            classes.Add(new AddClass
        //            {
        //                AddClassID = reader.GetInt32(0),
        //                AddClassCode = reader.GetString(1),
        //                AddClassName = reader.GetString(2)
        //            });
        //        }
        //    }
        //    return classes;
        //}

        public List<AddClass> GetClassNamesAndModes()   // Added new method to get class names and modes
        {
            var classList = new List<AddClass>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT ClName, ClMode FROM AddClasses", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    classList.Add(new AddClass
                    {
                        AddClassCode = reader.GetString(0), // ClName
                        AddClassName = reader.GetString(1)  // ClMode
                    });
                }
            }
            return classList;
        }
    }
}
