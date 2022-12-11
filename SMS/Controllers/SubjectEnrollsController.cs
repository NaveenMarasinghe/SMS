using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Services.Models;
using SMS.Services.SubjectEnroll;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectEnrollsController : ControllerBase
    {
        private readonly ISubjectEnrollRepository _subjectEnrollRepository;
        private readonly IMapper _mapper;
        public SubjectEnrollsController(ISubjectEnrollRepository repository, IMapper mapper) 
        {
            _subjectEnrollRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var data = _subjectEnrollRepository.GetAllSubjectEnrolls();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult EnrollSubject(EnrollSubjectDto enroll)
        {
            var studentEntity = _mapper.Map<EnrollSubjectDto>(enroll);
            var data = _subjectEnrollRepository.AddSubjectEnroll(studentEntity);
            return Ok(data);
        }
    }
}
