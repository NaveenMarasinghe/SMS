using Microsoft.EntityFrameworkCore;
using SMS.DataAccess;
using SMS.Models;
using SMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Students
{
    public class StudentService : IStudentRepository
    {
        private readonly SMSDbContext _context = new SMSDbContext();
        public List<Student> AllStudents()
        {
            return _context.Students.FromSqlInterpolated($"SELECT * FROM dbo.Students").ToList();
        }

        public Student GetOneStudent(int id)
        {
            return _context.Students.Find(id);
        }

        public Student AddNewStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return _context.Students.Find(student.Id);

        }
    }
}
