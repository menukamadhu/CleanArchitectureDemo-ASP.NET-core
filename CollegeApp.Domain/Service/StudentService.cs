using CollegeApp.Core.Entity;
using CollegeApp.Core.Interface;

namespace CollegeApp.Domain.Service;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Task<List<Student>> GetAll()
    {
        var students =  _studentRepository.GetAll();
        return students;
    }

    public Task<Student> GetById(int id)
    {
        var student = _studentRepository.GetById(id);
        return student;
    }

    public Task<bool> AddStudent(Student student)
    {
        var result = _studentRepository.AddStudent(student);
        return result;
    }

    public Task<Student> EditStudent(Student student)
    {
        var result = _studentRepository.EditStudent(student);
        return result;
    }

    public Task<bool> Delete(int id)
    {
        var result= _studentRepository.Delete(id);
        return result;
    }
}