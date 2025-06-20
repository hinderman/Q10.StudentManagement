using Microsoft.EntityFrameworkCore;

namespace Q10.StudentManagement.Enrollment.Infrastructure.Persistence.DataBaseContext
{
    public class EnrollmentDataBaseContext(DbContextOptions<EnrollmentDataBaseContext> pEnrollmentDataBaseContext) : DbContext(pEnrollmentDataBaseContext)
    {
        public DbSet<Domain.Entities.Enrollment> Enrollment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnrollmentDataBaseContext).Assembly);
        }
    }
}
