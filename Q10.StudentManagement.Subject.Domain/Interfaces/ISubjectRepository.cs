namespace Q10.StudentManagement.Subject.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Entities.Subject>> GetAllAsync();
        Task<Entities.Subject?> GetByIdAsync(Domain.ValueObjects.Id pId);
        Task AddAsync(Entities.Subject pSubject);
        Task UpdateAsync(Entities.Subject pSubject);
        Task DeleteAsync(Domain.ValueObjects.Id pId);
    }
}
