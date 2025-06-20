using ErrorOr;
using MediatR;
using Q10.StudentManagement.Enrollment.Application.Dtos;
using Q10.StudentManagement.Enrollment.Domain.Interfaces;

namespace Q10.StudentManagement.Enrollment.Application.Queries.Handler
{
    internal sealed class GetAllEnrollmentQueryHandler(IEnrollmentRepository pIEnrollmentRepository) : IRequestHandler<GetAllEnrollmentQuery, ErrorOr<IReadOnlyList<EnrollmentDto>>>
    {
        private readonly IEnrollmentRepository _IEnrollmentRepository = pIEnrollmentRepository ?? throw new ArgumentNullException(nameof(pIEnrollmentRepository));

        public async Task<ErrorOr<IReadOnlyList<EnrollmentDto>>> Handle(GetAllEnrollmentQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Enrollment> lstEnrollment = await _IEnrollmentRepository.GetAllAsync();


            return lstEnrollment.Select(e => new EnrollmentDto(e.Id.pId, e.StudentId.pId, e.SubjectId.pId, e.RegistrationDate, e.State)).ToList();
        }
    }
}
