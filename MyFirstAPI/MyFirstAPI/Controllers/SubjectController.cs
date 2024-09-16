using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstDapperAPI.Model;
using MyFirstDapperAPI.Service;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        SubjectService _subjectService = new SubjectService();

        [HttpPost]
        public IActionResult AddSubject([FromBody] SubjectModel subject)
        {
            _subjectService.AddSubject(subject);
            return Ok();
        }
    }
}
