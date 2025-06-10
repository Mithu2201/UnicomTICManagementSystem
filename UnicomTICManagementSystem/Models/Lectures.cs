using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Models
{
    internal class Lectures
    {
        public int Lec_ID { get; set; }
        public string Lec_Name { get; set; }
        public string Lec_Phone { get; set; }
        public string Lec_Address { get; set; }
        public int User_ID { get; set; }

    }
}
