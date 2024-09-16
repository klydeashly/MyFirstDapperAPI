using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstDapperAPI.Model;
using MyFirstDapperAPI.Service;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        CourseService _courseService = new CourseService();

        [HttpPost]
        public IActionResult AddCourse([FromBody] CourseModel course)
        {
            _courseService.AddCourse(course);
            return Ok();
        }
    }
}
