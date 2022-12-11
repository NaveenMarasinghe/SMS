using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.SubjectMarks
{
    public class SubjectMarksService : ISubjectMarksRepository
    {
        private readonly IConfiguration _configuration;
        public SubjectMarksService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<SubjectMarksDto> GetSubjectMarks(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DbCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT M.EnrollId, SubjectName, Marks, Name FROM Grades RIGHT JOIN (SELECT S.EnrollId, SubjectName, Marks FROM SubjectMarks RIGHT JOIN (SELECT SubjectEnroll.Id AS EnrollId, Subjects.Name AS SubjectName FROM SubjectEnroll LEFT JOIN Subjects ON SubjectEnroll.SubjectId=Subjects.Id WHERE SubjectEnroll.StudentId="+id+" ) AS S ON S.EnrollId=SubjectMarks.Id ) AS M ON M.Marks BETWEEN Grades.Min_mark AND Max_mark", con);
            DataTable dt = new DataTable();
            List<SubjectMarksDto> data = new List<SubjectMarksDto>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SubjectMarksDto subjectMarks = new SubjectMarksDto();
                    subjectMarks.EnrollId = Convert.ToInt32(dt.Rows[i]["EnrollId"]);
                    subjectMarks.SubjectName = Convert.ToString(dt.Rows[i]["SubjectName"]);
                    if (dt.Rows[i]["Marks"] is null)
                    {
                        subjectMarks.Marks = "-";
                    } else { subjectMarks.Marks = Convert.ToString(dt.Rows[i]["Marks"]); };
                    if (dt.Rows[i]["Name"] is null ) { 
                        subjectMarks.Grade = "-"; 
                    } else { subjectMarks.Grade = Convert.ToString(dt.Rows[i]["Name"]); }                    
                    data.Add(subjectMarks);
                }
            }
            return data;
        }

        public String AddSubjectMarks(CreateSubjectMarkDto marks)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DbCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("INSERT INTO SubjectMarks( EnrollId, Marks) VALUES('" + marks.EnrollId + "','" + marks.Marks + "')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return "Success";
        }

    }
}
