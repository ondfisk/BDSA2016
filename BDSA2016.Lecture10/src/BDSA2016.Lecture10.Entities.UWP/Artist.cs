using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDSA2016.Lecture10.Entities
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; } = new HashSet<Album>();
    }
}