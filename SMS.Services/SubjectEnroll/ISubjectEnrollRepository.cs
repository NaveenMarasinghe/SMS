using SMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.SubjectEnroll
{
    public interface ISubjectEnrollRepository
    {
        public List<SubjectEnrollDto> GetAllSubjectEnrolls();
        public String AddSubjectEnroll(EnrollSubjectDto enroll);
    }
}
