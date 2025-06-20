using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTICManagementSystem.Models
{
    internal class Attendence
    {
        public int AttendID { get; set; }
        public string Statusday { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
        public int SubID { get; set; }
        public string Subname { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }
}
