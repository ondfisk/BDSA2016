using System;

namespace BDSA2016.Lecture05.Lib.Students
{
    public class StudentListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfEnrolments { get; set; }

        public DateTime? LastEnrolmentDate { get; set; }
    }
}
