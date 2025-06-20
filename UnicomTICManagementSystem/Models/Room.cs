using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Models
{
    internal class Room
    {
        public int RoID { get; set; }
        public string Roname { get; set; }
        public string Rotype { get; set; }
        public string StudyMode { get; set; } // "Class" or "Exam"
        public string SessionName { get; set; } // ExName or ClassName
        public int? ClID { get; set; }
        public int? ExID { get; set; }

    }
}
