using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstDapperAPI.Model;
using MyFirstDapperAPI.Service;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        InstructorService _instructorService = new InstructorService();

        [HttpPost]
        public IActionResult AddInstructor([FromBody] InstructorModel instructor)
        {
            _instructorService.AddInstructor(instructor);
                return Ok();
        }
    }
}
