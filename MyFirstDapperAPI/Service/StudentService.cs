using Microsoft.AspNetCore.Mvc;
using MyFirstDapperAPI.Model;
using MyFirstDapperAPI.Repository;

namespace MyFirstDapperAPI.Service
{
    public class StudentService
    {
        StudentRepository _studentRepository = new StudentRepository();
        public StudentModel GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }
        public bool AddStudent(StudentModel student)
        {           
            return _studentRepository.Add(student);
        }
        public bool UpdateStudent(StudentModel student)
        {
            return _studentRepository.Update(student);
        }
        public bool DeleteStudent(StudentModel student)
        {
            return _studentRepository.Delete(student);
        }

        public StudentModel GetById(int id) 
        {
            return _studentRepository.GetById(id);
        }
    }
}
