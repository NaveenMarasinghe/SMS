using SMS.DataAccess;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly SMSDbContext _context = new SMSDbContext();
        public List<Student> AllStudents()
        {
            return _context.Students.ToList();
        }
    }
}
