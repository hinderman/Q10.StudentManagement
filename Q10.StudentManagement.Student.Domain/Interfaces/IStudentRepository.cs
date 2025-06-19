namespace Q10.StudentManagement.Student.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Entities.Student>> GetAllAsync();
        Task<Entities.Student?> GetByIdAsync(Guid id);
        Task AddAsync(Entities.Student student);
        Task UpdateAsync(Entities.Student student);
        Task DeleteAsync(Guid id);
    }
}
