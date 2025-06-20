using Microsoft.EntityFrameworkCore;

namespace Q10.StudentManagement.Subject.Infrastructure.Persistence.DataBaseContext
{
    public class SubjectDataBaseContext(DbContextOptions<SubjectDataBaseContext> pSubjectDataBaseContext) : DbContext(pSubjectDataBaseContext)
    {
        public DbSet<Domain.Entities.Subject> Subject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubjectDataBaseContext).Assembly);
        }
    }
}
