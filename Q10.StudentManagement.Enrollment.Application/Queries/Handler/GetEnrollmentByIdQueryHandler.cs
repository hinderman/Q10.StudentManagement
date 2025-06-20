using ErrorOr;
using MediatR;
using Q10.StudentManagement.Enrollment.Application.Dtos;
using Q10.StudentManagement.Enrollment.Domain.Interfaces;
using Q10.StudentManagement.Enrollment.Domain.ValueObjects;

namespace Q10.StudentManagement.Enrollment.Application.Queries.Handler
{
    internal sealed class GetEnrollmentByIdQueryHandler(IEnrollmentRepository pIEnrollmentRepository) : IRequestHandler<GetEnrollmentByIdQuery, ErrorOr<EnrollmentDto>>
    {
        private readonly IEnrollmentRepository _IEnrollmentRepository = pIEnrollmentRepository ?? throw new ArgumentNullException(nameof(pIEnrollmentRepository));

        public async Task<ErrorOr<EnrollmentDto>> Handle(GetEnrollmentByIdQuery request, CancellationToken cancellationToken)
        {
            if (await _IEnrollmentRepository.GetByIdAsync(new Id(request.pId)) is not Domain.Entities.Enrollment enrollment)
            {
                return Error.NotFound("Enrollment.NotFound", "No se pudo encontrar la matricula");
            }

            return new EnrollmentDto(enrollment.Id.pId, enrollment.StudentId.pId, enrollment.SubjectId.pId, enrollment.RegistrationDate, enrollment.State);
        }
    }
}
