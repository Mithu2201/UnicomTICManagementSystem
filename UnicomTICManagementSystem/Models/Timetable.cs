using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Models
{
    internal class Timetable
    {
        public int TiID { get; set; }
        public string Tiday { get; set; }
        public string Tislot { get; set; }
        public string Roname { get; set; }
        public int RoID { get; set; }

        public int CourseID { get; set; }
        public string CourseName { get; set; }

        public int SubID { get; set; }
        public string Subname { get; set; }

        public int LecID { get; set; }
        public string LecName { get; set; }



    }
}
