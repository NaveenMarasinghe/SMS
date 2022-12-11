using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Services.Grades;

namespace SMS.Controllers
{
    [Route("api/grades")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradesRepository _gradesService;

        public GradesController(IGradesRepository gradesService)
        {
            _gradesService = gradesService;
        }

        [HttpGet]
        public IActionResult GetAllGrades() 
        {
            var data = _gradesService.AllGrades();
            return Ok(data);
        }
    }
}
