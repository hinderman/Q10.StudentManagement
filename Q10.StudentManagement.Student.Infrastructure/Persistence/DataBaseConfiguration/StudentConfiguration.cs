using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Q10.StudentManagement.Student.Domain.ValueObjects;

namespace Q10.StudentManagement.Student.Infrastructure.Persistence.DataBaseConfiguration
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Domain.Entities.Student>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Student> builder)
        {
            builder.HasIndex(s => s.Document).HasDatabaseName("IX_Student_Document");
            builder.HasIndex(s => s.Email).HasDatabaseName("IX_Student_Email");

            builder.ToTable("Student");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()").HasConversion(id => id.pId, value => new Id(value));

            builder.Property(s => s.Email).HasColumnName("Email").HasMaxLength(30).HasConversion(email => email.Value, value => Email.Create(value)!).IsRequired();

            builder.Property(s => s.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

            builder.Property(s => s.Document).HasColumnName("Document").HasMaxLength(20).IsRequired();

            builder.Property(s => s.State).HasColumnName("State");
        }
    }
}
