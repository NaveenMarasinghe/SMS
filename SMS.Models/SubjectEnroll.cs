using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class SubjectEnroll
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
