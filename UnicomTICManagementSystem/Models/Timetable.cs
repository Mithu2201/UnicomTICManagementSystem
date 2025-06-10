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
        public int TimetablesID { get; set; }
        public int SubjectID { get; set; }
        public string TimeSlot { get; set; }
        public int RoomID { get; set; }
       
    }
}
