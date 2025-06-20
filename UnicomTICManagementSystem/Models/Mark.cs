using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Models
{
    internal class Mark
    {
        public int MaID { get; set; }
        public string Mamark { get; set; }
        public string Magrade { get; set; }
        
        public int StdID { get; set; }
        public string Stdname { get; set; }
       
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

    }
}
