using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SMS.DataAccess;
using SMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.SubjectEnroll
{
    public class SubjectEnrollService : ISubjectEnrollRepository
    {
        private readonly IConfiguration _configuration;
        public SubjectEnrollService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<SubjectEnrollDto> GetAllSubjectEnrolls()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DbCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT A.Id, StudentId,NameWithInitials,Name,Credits FROM Students RIGHT JOIN (SELECT SubjectEnroll.Id, StudentId, SubjectId, Name, Credits FROM SubjectEnroll LEFT JOIN Subjects ON SubjectEnroll.SubjectId=Subjects.Id) AS A ON A.StudentId=Students.Id", con);
            DataTable dt = new DataTable();
            List<SubjectEnrollDto> data = new List<SubjectEnrollDto>(); 
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i< dt.Rows.Count; i++)
                {
                    SubjectEnrollDto subjectEnroll = new SubjectEnrollDto();
                    subjectEnroll.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    subjectEnroll.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"]);
                    subjectEnroll.StudentName = Convert.ToString(dt.Rows[i]["NameWithInitials"]);
                    subjectEnroll.SubjectName = Convert.ToString(dt.Rows[i]["Name"]);
                    subjectEnroll.Credits = Convert.ToInt32(dt.Rows[i]["Credits"]);
                    data.Add(subjectEnroll);
                }
            }
            return data;
        }

        public String AddSubjectEnroll(EnrollSubjectDto enroll)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DbCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("INSERT INTO SubjectEnroll( StudentId, SubjectId) VALUES('"+enroll.StudentId+"','"+enroll.SubjectId+"')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return "Success";
        }
    }
}
