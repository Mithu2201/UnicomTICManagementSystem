using System;
using System.Collections.Generic;
using System.Data;      
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using static System.Net.Mime.MediaTypeNames;

namespace UnicomTICManagementSystem.Models
{
    internal class Student
    {
        public int Std_ID { get; set; }
        public string Std_Name { get; set; }
        public string Std_Phone { get; set; }
        public string Std_Address { get; set; }
        public int User_ID { get; set; }
        
        
    }
}
