using SMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.SubjectMarks
{
    public interface ISubjectMarksRepository
    {
        public List<SubjectMarksDto> GetSubjectMarks(int id);
        public String AddSubjectMarks(CreateSubjectMarkDto createMarks);
    }
}
