using CollegeApp.Application.Entities;
using CollegeApp.Application.Interfaces;
using CollegeApp.Infrastructure.DBService;

namespace CollegeApp.Application.Domain;

public class StudentService : IStudentService
{
    private readonly IDbService _dbService;

    public StudentService(IDbService dbService)
    {
        _dbService = dbService;
    }

    public async Task<List<Student>> GetAll()
    {
        var students = await _dbService.GetAll<Student>("SELECT * FROM public.student", new { });
        return students;
    }

    public async Task<Student> GetById(int id)
    {
        var Student = await _dbService.GetAsync<Student>("SELECT * FROM public.student WHERE id=@id", new { id });
        return Student;
    }

    public async Task<bool> AddStudent(Student student)
    {
        var result = await _dbService.EditData(
            "INSERT INTO public.student (id,name,email,address) VALUES (@Id,@Name,@Email,@Address)",student
            );
        return true;
    }

    public async Task<Student> EditStudent(Student student)
    {
        var result = await _dbService.EditData("UPDATE public.student SET name=@Name, email=@Email, address=@Address",student);
        return student;
    }

    public async Task<bool> Delete(int id)
    {
        var deleteStudent = await _dbService.EditData("DELETE FROM public.student WHERE id=@id", new { id });
        return true;
    }
}