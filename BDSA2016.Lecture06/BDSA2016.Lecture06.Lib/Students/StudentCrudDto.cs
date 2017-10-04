using System.ComponentModel.DataAnnotations;

namespace BDSA2016.Lecture05.Lib.Students
{
    public class StudentCrudDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
