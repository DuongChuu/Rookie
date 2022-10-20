using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
       : base(options)
        {
        }
        public DbSet<Student> students { get; set; } = null!;
    }
}