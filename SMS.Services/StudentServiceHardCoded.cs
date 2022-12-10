using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class StudentServiceHardCoded : IStudentRepository
    {
        public List<Student> AllStudents()
        {
            var students = new List<Student>();

            var student1 = new Student
            {
                Id = 1,
                NameWithInitials = "H.A.Perera",
                FirstName = "Aravinda",
                LastName = "Perera",
                Email = "aravindaperera@gmail.com",
                Address = "Negegoda"
            };
            students.Add(student1);

            var student2 = new Student
            {
                Id = 2,
                NameWithInitials = "T.K.Bandara",
                FirstName = "Kasun",
                LastName = "Bandara",
                Email = "kasunbandara@gmail.com",
                Address = "Dehiwala"
            };
            students.Add(student2);

            return students;
        }
    }
}
