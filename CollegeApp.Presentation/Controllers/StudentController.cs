using CollegeApp.Application.Entities;
using CollegeApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureDemo.Controllers;

[ApiController]
[Route("api/students")]

public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _studentService.GetAll();
        return Ok(students);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Enter valid Id");
        }
        var student = await _studentService.GetById(id);
        if (student == null)
        {
            return NotFound($"Student is not found in id {id}");
        }
        return Ok(student);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Insert([FromBody] Student student)
    {
        var result = await _studentService.AddStudent(student);
        return Ok(result);
    }

    [HttpPut("edit")]
    public async Task<IActionResult> Edit([FromBody] Student student)
    {
        var result = await _studentService.EditStudent(student);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Enter valid Id");
        }
        var result = await _studentService.Delete(id);
        return Ok(result);
    }
}