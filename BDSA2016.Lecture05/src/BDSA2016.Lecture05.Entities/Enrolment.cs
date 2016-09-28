using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2016.Lecture05.Entities
{
    public class Enrolment
    {
        public int Id { get; set; }

        public DateTime EnrolmentDate { get; set; }

        public int CourseDateId { get; set; }

        public Date CourseDate { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
