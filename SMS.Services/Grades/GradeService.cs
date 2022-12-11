using Microsoft.EntityFrameworkCore;
using SMS.DataAccess;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Grades
{
    public class GradeService : IGradesRepository
    {
        private readonly SMSDbContext _context = new SMSDbContext();
        public List<Grade> AllGrades()
        {
            return _context.Grades.FromSqlInterpolated($"SELECT * FROM dbo.Grades").ToList();
        }

    }
}
