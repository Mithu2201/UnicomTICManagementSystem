using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTICManagementSystem.Models
{
    internal class StudentAttendanceModel
    {
        public int StdId { get; set; }
        public string StdName { get; set; }
        public string StdPhone { get; set; }
        public string StdAddress { get; set; }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public string AttendanceDate { get; set; }
        public string Status { get; set; }
    }
}
