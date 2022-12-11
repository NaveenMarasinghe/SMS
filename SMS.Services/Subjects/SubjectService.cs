using Microsoft.EntityFrameworkCore;
using SMS.DataAccess;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Subjects
{
    public class SubjectService : ISubjectRepository
    {
        private readonly SMSDbContext _context = new SMSDbContext();
        public List<Subject> AllSubjects()
        {
            return _context.Subjects.FromSqlInterpolated($"SELECT * FROM dbo.Subjects").ToList();
        }
    }
}
