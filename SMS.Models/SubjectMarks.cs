using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class SubjectMarks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(10)]
        public int EnrollId { get; set; }
        [MaxLength(3)]
        public int Marks { get; set; }
    }
}
