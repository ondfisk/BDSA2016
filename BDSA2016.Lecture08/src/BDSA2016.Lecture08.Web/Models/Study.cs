using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2016.Lecture08.Web.Models
{
    public class Study
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
    }
}
