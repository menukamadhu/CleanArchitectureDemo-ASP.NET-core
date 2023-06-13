using System.Data;
using CollegeApp.Core.Entity;
using CollegeApp.Core.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CollegeApp.Infrastructure.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly IDbConnection _db;

    public StudentRepository(IConfiguration configuration)
    {
        _db = new NpgsqlConnection(configuration.GetConnectionString("CollegeDB"));
    }
    
    public async Task<List<Student>> GetAll()
    {
        var students = await _db.QueryAsync<Student>("SELECT * FROM public.student");
        return students.ToList();
    }

    public async Task<Student> GetById(int id)
    {
        var student = await _db.QueryFirstOrDefaultAsync<Student>("SELECT * FROM public.student WHERE id = @Id", new { Id = id });
        return student;
    }

    public async Task<bool> AddStudent(Student student)
    {
        var result = await _db.ExecuteAsync(
            "INSERT INTO public.student (id, name, email, address) VALUES (@Id, @Name, @Email, @Address)",
            student
        );

        return result > 0;
    }

    public async Task<Student> EditStudent(Student student)
    {
        await _db.ExecuteAsync(
            "UPDATE public.student SET name = @Name, email = @Email, address = @Address WHERE id = @Id",
            student
        );

        return student;
    }
    
    public async Task<bool> Delete(int id)
    {
        var result = await _db.ExecuteAsync("DELETE FROM public.student WHERE id = @Id", new { Id = id });
        return result > 0;
    }
}