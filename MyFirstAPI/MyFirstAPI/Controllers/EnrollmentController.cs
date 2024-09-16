using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstDapperAPI.Model;
using MyFirstDapperAPI.Service;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        EnrollmentService _enrollmentService = new EnrollmentService();

        [HttpPost]
        public IActionResult AddEnrollment([FromBody] EnrollmentModel enrollment)
        {
            _enrollmentService.AddEnrollment(enrollment);
            return Ok();
        }
    }
}
