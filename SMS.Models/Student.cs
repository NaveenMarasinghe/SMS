﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string NameWithInitials { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }      
    }
}
