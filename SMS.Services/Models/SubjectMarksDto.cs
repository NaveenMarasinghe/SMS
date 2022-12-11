using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Models
{
    public class SubjectMarksDto
    {
        public int EnrollId { get; set; }

        public string SubjectName { get; set; }
        public string Marks { get; set; }
        public string Grade { get; set; }
    }
}
