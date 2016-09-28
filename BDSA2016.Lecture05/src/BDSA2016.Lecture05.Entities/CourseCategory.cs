using System.ComponentModel.DataAnnotations;

namespace BDSA2016.Lecture05.Entities
{
    public class CourseCategory
    {
        [Key]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        [Key]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
