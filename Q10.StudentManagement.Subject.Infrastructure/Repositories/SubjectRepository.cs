using Microsoft.EntityFrameworkCore;
using Q10.StudentManagement.Subject.Domain.Interfaces;
using Q10.StudentManagement.Subject.Domain.ValueObjects;
using Q10.StudentManagement.Subject.Infrastructure.Persistence.DataBaseContext;

namespace Q10.StudentManagement.Subject.Infrastructure.Repositories
{
    internal class SubjectRepository(SubjectDataBaseContext pSubjectDataBaseContext) : ISubjectRepository
    {
        private readonly SubjectDataBaseContext _SubjectDataBaseContext = pSubjectDataBaseContext ?? throw new ArgumentNullException(nameof(pSubjectDataBaseContext));

        public async Task AddAsync(Domain.Entities.Subject pSubject)
        {
            await _SubjectDataBaseContext.Subject.AddAsync(pSubject);
            await _SubjectDataBaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Id pId) => await _SubjectDataBaseContext.Subject.Where(s => s.Id == pId).ExecuteUpdateAsync(s => s.SetProperty(s => s.State, false));

        public async Task<IEnumerable<Domain.Entities.Subject>> GetAllAsync() => await _SubjectDataBaseContext.Subject.Where(s => s.State).ToArrayAsync();

        public async Task<Domain.Entities.Subject?> GetByIdAsync(Id pId) => await _SubjectDataBaseContext.Subject.SingleOrDefaultAsync(s => s.Id == pId && s.State);

        public async Task UpdateAsync(Domain.Entities.Subject pSubject) =>
            await _SubjectDataBaseContext.Subject
                .Where(s => s.Id == pSubject.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(s => s.Name, pSubject.Name)
                    .SetProperty(s => s.Code, pSubject.Code)
                    .SetProperty(s => s.Credits, pSubject.Credits)
                    .SetProperty(s => s.State, true));
    }
}
