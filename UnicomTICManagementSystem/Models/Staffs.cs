using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Models
{
    internal class Staffs
    {
        public int Stf_ID { get; set; }
        public string Stf_Name { get; set; }
        public string Stf_Phone { get; set; }
        public string Stf_Address { get; set; }
        public int User_ID { get; set; }

    }
}
