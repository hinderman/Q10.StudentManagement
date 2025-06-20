using Microsoft.EntityFrameworkCore;
using Q10.StudentManagement.Enrollment.Domain.Interfaces;
using Q10.StudentManagement.Enrollment.Domain.ValueObjects;
using Q10.StudentManagement.Enrollment.Infrastructure.Persistence.DataBaseContext;

namespace Q10.StudentManagement.Enrollment.Infrastructure.Repositories
{
    public class EnrollmentRepository(EnrollmentDataBaseContext pEnrollmentDataBaseContext) : IEnrollmentRepository
    {
        private readonly EnrollmentDataBaseContext _EnrollmentDataBaseContext = pEnrollmentDataBaseContext ?? throw new ArgumentNullException(nameof(pEnrollmentDataBaseContext));

        public async Task AddAsync(Domain.Entities.Enrollment pEnrollment)
        {
            await _EnrollmentDataBaseContext.Enrollment.AddAsync(pEnrollment);
            await _EnrollmentDataBaseContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Id pId) => _EnrollmentDataBaseContext.Enrollment.Where(e => e.Id == pId).ExecuteUpdateAsync(e => e.SetProperty(e => e.State, false));

        public async Task<IEnumerable<Domain.Entities.Enrollment>> GetAllAsync() => await _EnrollmentDataBaseContext.Enrollment.Where(e => e.State).ToArrayAsync();

        public Task<Domain.Entities.Enrollment?> GetByIdAsync(Id pId) => _EnrollmentDataBaseContext.Enrollment.SingleOrDefaultAsync(e => e.Id == pId && e.State);

        public async Task UpdateAsync(Domain.Entities.Enrollment pEnrollment) =>
            await _EnrollmentDataBaseContext.Enrollment
                .Where(e => e.Id == pEnrollment.Id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(e => e.StudentId, pEnrollment.StudentId)
                    .SetProperty(e => e.SubjectId, pEnrollment.SubjectId)
                    .SetProperty(e => e.RegistrationDate, pEnrollment.RegistrationDate)
                    .SetProperty(e => e.State, true));
    }
}
