namespace Q10.StudentManagement.Student.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Entities.Student>> GetAllAsync();
        Task<Entities.Student?> GetByIdAsync(Domain.ValueObjects.Id pId);
        Task AddAsync(Entities.Student pStudent);
        Task UpdateAsync(Entities.Student pStudent);
        Task DeleteAsync(Domain.ValueObjects.Id pId);
    }
}
