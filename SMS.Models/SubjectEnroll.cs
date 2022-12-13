using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class SubjectEnroll
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(10)]
        public int SubjectId { get; set; }
    }
}
