using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Subjects
{
    public interface ISubjectRepository
    {
        public List<Subject> AllSubjects();
    }
}
