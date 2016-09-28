using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDSA2016.Lecture05.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
