using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using Q10.StudentManagement.Enrollment.Domain.Interfaces;
using Q10.StudentManagement.Enrollment.Domain.ValueObjects;

namespace Q10.StudentManagement.Enrollment.Application.Commands.Handler
{
    internal sealed class UpdateEnrollmentCommandHandler(IEnrollmentRepository pIEnrollmentRepository) : IRequestHandler<UpdateEnrollmentCommand, ErrorOr<Unit>>
    {
        private readonly IEnrollmentRepository _IEnrollmentRepository = pIEnrollmentRepository ?? throw new ArgumentNullException(nameof(pIEnrollmentRepository));

        public async Task<ErrorOr<Unit>> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            if (await _IEnrollmentRepository.GetByIdAsync(new Id(request.pId)) is not Domain.Entities.Enrollment enrollment)
            {
                return Error.NotFound("Enrollment.NotFound", "La matricula que desea actualizar no fue encontrado.");
            }

            await _IEnrollmentRepository.UpdateAsync(Domain.Entities.Enrollment.Create(new Id(request.pId), new Id(request.pStudentId), new Id(request.pSubjectId), request.pRegistrationDate, request.pState));

            return Unit.Value;
        }
    }
}
