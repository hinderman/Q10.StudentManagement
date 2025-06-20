using ErrorOr;
using MediatR;
using Q10.StudentManagement.Enrollment.Domain.Interfaces;
using Q10.StudentManagement.Enrollment.Domain.ValueObjects;

namespace Q10.StudentManagement.Enrollment.Application.Commands.Handler
{
    internal sealed class CreateEnrollmentCommandHandler(IEnrollmentRepository pIEnrollmentRepository) : IRequestHandler<CreateEnrollmentCommand, ErrorOr<Unit>>
    {
        private readonly IEnrollmentRepository _IEnrollmentRepository = pIEnrollmentRepository ?? throw new ArgumentNullException(nameof(pIEnrollmentRepository));

        public async Task<ErrorOr<Unit>> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            Guid newGuid = Guid.NewGuid();
            Domain.Entities.Enrollment objEnrollment = Domain.Entities.Enrollment.Create(new Id(newGuid), new Id(request.pStudentId), new Id(request.pSubjectId), request.pRegistrationDate, request.pState);

            await _IEnrollmentRepository.AddAsync(objEnrollment);

            return Unit.Value;
        }
    }
}
