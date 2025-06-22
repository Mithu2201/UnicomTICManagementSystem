using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTICManagementSystem.Models
{
    internal class StudentMarkModel
    {
        public int StdId { get; set; }
        public string StdName { get; set; }
        public string StdAddress { get; set; }
        public string StdPhone { get; set; }
        public string CourseName { get; set; }
        public int CourseId { get; set; }
    }

    internal class SubjectItem
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public override string ToString() => SubjectName;
    }

    internal class MarkDetail
    {
        public string ExamName { get; set; }
        public int MarkScore { get; set; }
        public string MarksGrade { get; set; }
    }
}
