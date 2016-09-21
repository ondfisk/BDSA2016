using System.ComponentModel.DataAnnotations;

namespace BDSA2016.Lecture04.Lib
{
    public class Character
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string GivenName { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Species { get; set; }

        [StringLength(50)]
        public string Origin { get; set; }
        
        public int? Age { get; set; }

        public override string ToString() => $"{GivenName} {Surname} - a {Species} from {Origin}, age: {Age}";
    }
}