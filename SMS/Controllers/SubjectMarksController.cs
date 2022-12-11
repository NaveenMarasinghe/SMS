using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Services.Models;
using SMS.Services.SubjectMarks;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectMarksController : ControllerBase
    {
        private readonly ISubjectMarksRepository _subjectMarksRepository;
        private readonly IMapper _mapper;

        public SubjectMarksController(ISubjectMarksRepository repository, IMapper mapper)
        {
            _subjectMarksRepository = repository;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _subjectMarksRepository.GetSubjectMarks(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddMarks(CreateSubjectMarkDto marks)
        {

            var data = _subjectMarksRepository.AddSubjectMarks(marks);
            return Ok(data);
        }
    }
}
