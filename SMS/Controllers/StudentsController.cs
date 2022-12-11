using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Services.Students;
using System.Linq;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentService;

        public StudentsController(IStudentRepository repository)
        {
            _studentService = repository;
        }

        [HttpGet("{id?}")]
        public IActionResult GetStudents(int? id) 
        {
            var studentsData = _studentService.AllStudents();

            if (id is null) return Ok(studentsData);

            studentsData = studentsData.Where(t =>t.Id == id).ToList();

            return Ok(studentsData);
        }
    }
}
