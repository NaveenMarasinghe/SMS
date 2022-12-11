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
        public Student GetOneStudent(int id);
        public Student AddNewStudent(Student student);
        public void UpdateStudent(Student student);
    }
}
