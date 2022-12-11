using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Students
{
    public interface IStudentRepository
    {
        public List<Student> AllStudents();
    }
}
