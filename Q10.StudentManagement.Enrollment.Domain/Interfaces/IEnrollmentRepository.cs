namespace Q10.StudentManagement.Enrollment.Domain.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Entities.Enrollment>> GetAllAsync();
        Task<Entities.Enrollment?> GetByIdAsync(ValueObjects.Id pId);
        Task AddAsync(Entities.Enrollment pEnrollment);
        Task UpdateAsync(Entities.Enrollment pEnrollment);
        Task DeleteAsync(ValueObjects.Id pId);
    }
}
