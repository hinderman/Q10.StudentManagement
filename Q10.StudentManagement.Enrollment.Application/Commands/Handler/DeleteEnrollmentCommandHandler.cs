using ErrorOr;
using MediatR;
using Q10.StudentManagement.Enrollment.Domain.Interfaces;
using Q10.StudentManagement.Enrollment.Domain.ValueObjects;

namespace Q10.StudentManagement.Enrollment.Application.Commands.Handler
{
    internal sealed class DeleteEnrollmentCommandHandler(IEnrollmentRepository pIEnrollmentRepository) : IRequestHandler<DeleteEnrollmentCommand, ErrorOr<Unit>>
    {
        private readonly IEnrollmentRepository _IEnrollmentRepository = pIEnrollmentRepository ?? throw new ArgumentNullException(nameof(pIEnrollmentRepository));
        public async Task<ErrorOr<Unit>> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
        {
            if (await _IEnrollmentRepository.GetByIdAsync(new Id(request.pId)) is not Domain.Entities.Enrollment enrollment)
            {
                return Error.NotFound("Enrollment.NotFound", "La matricula que desea eliminar no fue encontrado.");
            }

            await _IEnrollmentRepository.DeleteAsync(new Id(request.pId));

            return Unit.Value;
        }
    }
}
