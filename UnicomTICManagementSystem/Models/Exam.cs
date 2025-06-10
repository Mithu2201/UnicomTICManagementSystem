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
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public int SubjectID { get; set; }
        
    }
}
