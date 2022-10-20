using EFGetStarted.DTOs;

namespace EFGetStarted.Services;

public interface IStudentService
{
    AddStudentResponse Create(AddStudentRequest createModel);
    IEnumerable<GetStudentRespone> GetAll();
    UpdateStudentRespone Update(int id, UpdateStudentRequest updateModel);
    bool Delete(int id);
}