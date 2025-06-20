using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Q10.StudentManagement.Enrollment.Domain.ValueObjects;

namespace Q10.StudentManagement.Enrollment.Infrastructure.Persistence.DataBaseConfiguration
{
    internal class EnrollmentConfiguration : IEntityTypeConfiguration<Domain.Entities.Enrollment>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Enrollment> builder)
        {
            builder.HasIndex(e => new { e.StudentId, e.SubjectId }).HasDatabaseName("IX_Enrollment_StudentSubject");

            builder.ToTable("Enrollment");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()").HasConversion(id => id.pId, value => new Id(value));

            builder.Property(s => s.StudentId).HasColumnName("StudentId").HasConversion(id => id.pId, value => new Id(value)).IsRequired();

            builder.Property(s => s.SubjectId).HasColumnName("SubjectId").HasConversion(id => id.pId, value => new Id(value)).IsRequired();

            builder.Property(s => s.RegistrationDate).HasColumnName("RegistrationDate").IsRequired();

            builder.Property(s => s.State).HasColumnName("State").IsRequired();
        }
    }
}
