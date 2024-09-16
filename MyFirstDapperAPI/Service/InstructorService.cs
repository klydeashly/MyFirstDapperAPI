using MyFirstDapperAPI.Model;
using MyFirstDapperAPI.Repository;

namespace MyFirstDapperAPI.Service
{
    public class InstructorService
    {
        InstructorRepository _instructorRepository = new InstructorRepository();

        public bool AddInstructor(InstructorModel instructor)
        {
            return _instructorRepository.Add(instructor);
        }
    }
}
