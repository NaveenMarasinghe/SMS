using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Services.Models;
using SMS.Services.Students;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository repository, IMapper mapper)
        {
            _studentService = repository;
            _mapper = mapper;   
        }

        [HttpGet]
        public ActionResult<ICollection<StudentDto>> GetStudents() 
        {
            var students = _studentService.AllStudents();

            var mappedStudents = _mapper.Map<ICollection<StudentDto>>(students);     

            return Ok(mappedStudents);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var data = _studentService.GetOneStudent(id);
            return Ok(data);
        }

        [HttpPost]
        public ActionResult<StudentDto> AddNewStudent(CreateStudentDto student)
        {
            var studentEntity = _mapper.Map<Student>(student);
            var newStudent = _studentService.AddNewStudent(studentEntity);

            var studentForReturn = _mapper.Map<StudentDto>(newStudent);
            return studentForReturn;
        }

        [HttpPut]
        public ActionResult UpdateStudent(int id, UpdateStudentDto student)
        {
            var updatingStudent = _studentService.GetOneStudent(id);

            if (updatingStudent is null)
            {
                return NotFound();
            }

            _mapper.Map(student, updatingStudent);

            _studentService.UpdateStudent(updatingStudent);

            return NoContent();
        }
    }
}
