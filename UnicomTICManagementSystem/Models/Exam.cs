using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Models
{
    internal class Exam
    {
        public int ExID { get; set; }
        public string Exname { get; set; }
        public string Exmode { get; set; }
        public string Subname { get; set; }
        public int SubID { get; set; }

    }
}
