using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2016.Lecture05.Entities
{
    public class Enrolment
    {
        [Key]
        public int Id { get; set; }

        public DateTime EnrolmentDate { get; set; }

        public int DateId { get; set; }

        public Date Date { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
