using Q10.StudentManagement.Student.Domain.Interfaces;

namespace Q10.StudentManagement.Student.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Task AddAsync(Domain.Entities.Student student)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Student?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Entities.Student student)
        {
            throw new NotImplementedException();
        }
    }
}
