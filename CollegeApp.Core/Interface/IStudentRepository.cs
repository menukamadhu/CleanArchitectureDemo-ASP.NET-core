using CollegeApp.Core.Entity;

namespace CollegeApp.Core.Interface;

public interface IStudentRepository
{
    Task<List<Student>> GetAll();
    Task<Student> GetById(int id);
    Task<bool> AddStudent(Student student);
    Task<Student> EditStudent(Student student);
    Task<bool> Delete(int id);
}