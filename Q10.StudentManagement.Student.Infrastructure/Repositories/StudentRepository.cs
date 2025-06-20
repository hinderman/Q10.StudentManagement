using Microsoft.EntityFrameworkCore;
using Q10.StudentManagement.Student.Domain.Interfaces;
using Q10.StudentManagement.Student.Infrastructure.Persistence.DataBaseContext;

namespace Q10.StudentManagement.Student.Infrastructure.Repositories
{
    public class StudentRepository(StudentDataBaseContext pStudentDataBaseContext) : IStudentRepository
    {
        private readonly StudentDataBaseContext _StudentDataBaseContext = pStudentDataBaseContext ?? throw new ArgumentNullException(nameof(pStudentDataBaseContext));

        public async Task AddAsync(Domain.Entities.Student pStudent)
        {
            await _StudentDataBaseContext.Student.AddAsync(pStudent); 
            await _StudentDataBaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Domain.ValueObjects.Id pId) => await _StudentDataBaseContext.Student.Where(s => s.Id == pId).ExecuteUpdateAsync(s => s.SetProperty(s => s.State, false));

        public async Task<IEnumerable<Domain.Entities.Student>> GetAllAsync() =>  await _StudentDataBaseContext.Student.Where(s => s.State).ToArrayAsync();

        public async Task<Domain.Entities.Student?> GetByIdAsync(Domain.ValueObjects.Id pId) => await _StudentDataBaseContext.Student.SingleOrDefaultAsync(s => s.Id == pId && s.State);

        public async Task UpdateAsync(Domain.Entities.Student pStudent) => 
            await _StudentDataBaseContext.Student
                .Where(s => s.Id == pStudent.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(s => s.Email, pStudent.Email)
                    .SetProperty(s => s.Name, pStudent.Name)
                    .SetProperty(s => s.Document, pStudent.Document)
                    .SetProperty(s => s.State, true));
    }
}
