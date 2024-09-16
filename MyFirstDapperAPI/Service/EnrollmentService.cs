using MyFirstDapperAPI.Model;
using MyFirstDapperAPI.Repository;

namespace MyFirstDapperAPI.Service
{
    public class EnrollmentService
    {
        EnrollmentRepository _enrollmentRepository = new EnrollmentRepository();

        public bool AddEnrollment (EnrollmentModel enrollment)
        {
            return _enrollmentRepository.Add(enrollment);
        }
    }
}
