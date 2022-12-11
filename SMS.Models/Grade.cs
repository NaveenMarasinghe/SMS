using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class Grade
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(3)]
        public int Min_mark { get; set; }
        [Required]
        [MaxLength(3)]
        public int Max_mark { get; set;}
    }
}
