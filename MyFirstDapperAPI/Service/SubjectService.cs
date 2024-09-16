using MyFirstDapperAPI.Model;
using MyFirstDapperAPI.Repository;

namespace MyFirstDapperAPI.Service
{
    public class SubjectService
    {
        SubjectRepository _subjectRepository = new SubjectRepository();

        public bool AddSubject (SubjectModel subject)
        {
          return  _subjectRepository.Add(subject);         
        }
    }
}
