using Microsoft.EntityFrameworkCore;

namespace Q10.StudentManagement.Student.Infrastructure.Persistence.DataBaseContext
{
    public class StudentDataBaseContext(DbContextOptions<StudentDataBaseContext> pStudentDataBaseContext) : DbContext(pStudentDataBaseContext)
    {
        public DbSet<Domain.Entities.Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentDataBaseContext).Assembly);
        }
    }
}
