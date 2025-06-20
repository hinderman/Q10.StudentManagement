using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Q10.StudentManagement.Subject.Domain.ValueObjects;

namespace Q10.StudentManagement.Subject.Infrastructure.Persistence.DataBaseConfiguration
{
    internal class SubjectConfiguration : IEntityTypeConfiguration<Domain.Entities.Subject>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Subject> builder)
        {
            builder.HasIndex(s => s.Code).HasDatabaseName("IX_Subject_Code");

            builder.ToTable("Subject");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()").HasConversion(id => id.pId, value => new Id(value));

            builder.Property(s => s.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

            builder.Property(s => s.Code).HasColumnName("Code").HasMaxLength(20).IsRequired();

            builder.Property(s => s.Credits).HasColumnName("Credits").IsRequired();

            builder.Property(s => s.State).HasColumnName("State");
        }
    }
}
