using EFGetStarted.Data;
using EFGetStarted.Models;

namespace EFGetStarted.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(StudentContext context) : base(context)
    {
    }
}