using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstDapperAPI.Model;
using MyFirstDapperAPI.Service;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentService _studentService = new StudentService();
        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentModel student)
        {
            _studentService.AddStudent(student);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateStudent([FromBody] StudentModel student)
        {
            _studentService.UpdateStudent(student);
            return Ok("Pasok na sya");
        }
        [HttpDelete]
        public IActionResult DeleteStudent([FromBody] StudentModel student)
        {
            _studentService.DeleteStudent(student);
            return Ok();
        }
        [HttpGet ("{id}")] //routing 
        public IActionResult GetById(int id)
        {
         var student = _studentService.GetById(id);
            return Ok(student);
        }
    }
}
