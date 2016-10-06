using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDSA2016.Lecture05.Entities
{
    public class Date
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string Comment { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; } = new HashSet<Enrolment>();
    }
}
