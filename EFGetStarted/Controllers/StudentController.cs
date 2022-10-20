using EFGetStarted.DTOs;
using Microsoft.AspNetCore.Mvc;
using EFGetStarted.Services;

namespace EFGetStarted.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public AddStudentResponse Add([FromBody] AddStudentRequest addRequest)
    {
        return _studentService.Create(addRequest);
    }

    [HttpGet]
    public IEnumerable<GetStudentRespone> GetAll()
    {
        return _studentService.GetAll();
    }

    [HttpPut("{id}")]
    public UpdateStudentRespone Update(int id, [FromBody] UpdateStudentRequest requestModel)
    {
        return _studentService.Update(id, requestModel);
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        return _studentService.Delete(id);
    }
}