using EFGetStarted.DTOs;
using EFGetStarted.Models;
using EFGetStarted.Repositories;

namespace EFGetStarted.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public AddStudentResponse Create(AddStudentRequest createModel)
    {
        var createStudent = new Student
        {
            FirstName = createModel.FirstName,
            LastName = createModel.LastName,
            City = createModel.City,
            State = createModel.State
        };

        var student = _studentRepository.Create(createStudent);

        _studentRepository.SaveChanges();

        return new AddStudentResponse
        {
            Id = student.Id,
            FirstName = student.FirstName
        };
    }

    public bool Delete(int id)
    {
        var deleteStudent = _studentRepository.Get(student => student.Id == id);

        if (deleteStudent == null) return false;

        bool isTest = _studentRepository.Delete(deleteStudent);
        _studentRepository.SaveChanges();

        return isTest;
    }

    public IEnumerable<GetStudentRespone> GetAll()
    {
        return _studentRepository.GetAll(getStudent => true).
            Select(student => new GetStudentRespone
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                City = student.City,
                State = student.State
            });
    }

    public UpdateStudentRespone Update(int id, UpdateStudentRequest updateModel)
    {
        var student = _studentRepository.Get(student => student.Id == id);

        if (student == null) return null;
        if (updateModel.FirstName != null && updateModel.LastName != null
           && updateModel.City != null && updateModel.State != null)
        {
            student.FirstName = updateModel.FirstName;
            student.LastName = updateModel.LastName;
            student.City = updateModel.City;
            student.State = updateModel.State;
        }
        var updatedStudent = _studentRepository.Update(student);
        _studentRepository.SaveChanges();

        return new UpdateStudentRespone
        {
            FirstName = updatedStudent.FirstName,
            LastName = updatedStudent.LastName,
            City = updatedStudent.City,
            State = updatedStudent.State
        };
    }
}