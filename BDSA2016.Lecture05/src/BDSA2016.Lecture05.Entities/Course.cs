using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDSA2016.Lecture05.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Date> Dates { get; set; } = new HashSet<Date>();
    }
}
