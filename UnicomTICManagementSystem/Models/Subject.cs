using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Models
{
    internal class Subject
    {
        public int SubID { get; set; }
        public string SubCode { get; set; }
        public string Subname { get; set; }
        public string CourseName { get; set; }
        public int CourseID { get; set; }
        
    }
}
