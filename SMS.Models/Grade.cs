using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Min_mark { get; set; }
        public int Max_mark { get; set;}
    }
}
