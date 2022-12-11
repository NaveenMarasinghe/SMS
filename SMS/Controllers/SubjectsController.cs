using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Services.Subjects;

namespace SMS.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectService;

        public SubjectsController(ISubjectRepository repository)
        {
            _subjectService = repository;
        }

        [HttpGet]
        public IActionResult GetAllSubjects()
        {
            var data = _subjectService.AllSubjects();
            return Ok(data);
        }
    }
}
