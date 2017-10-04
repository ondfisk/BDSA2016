using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDSA2016.Lecture05.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; } = new HashSet<Enrolment>();
    }
}
