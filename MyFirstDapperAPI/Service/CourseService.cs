using MyFirstDapperAPI.Model;
using MyFirstDapperAPI.Repository;

namespace MyFirstDapperAPI.Service
{
    public class CourseService
    {
        CourseRepository _courseRepository = new CourseRepository();

        public CourseModel GetCourseById(int id)
        {           
            return _courseRepository.GetById(id);
        }

        public bool AddCourse(CourseModel course)
        {
            return _courseRepository.Add(course);
        }
    }
}
