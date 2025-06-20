using ErrorOr;
using MediatR;
using Q10.StudentManagement.Subject.Domain.Interfaces;
using Q10.StudentManagement.Subject.Domain.ValueObjects;

namespace Q10.StudentManagement.Subject.Application.Commands.Handler
{
    internal sealed class UpdateSubjectCommandHandler(ISubjectRepository pISubjectRepository) : IRequestHandler<UpdateSubjectCommand, ErrorOr<Unit>>
    {
        private readonly ISubjectRepository _ISubjectRepository = pISubjectRepository ?? throw new ArgumentNullException(nameof(pISubjectRepository));

        public async Task<ErrorOr<Unit>> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            if (await _ISubjectRepository.GetByIdAsync(new Id(request.pId)) is not Domain.Entities.Subject subject)
            {
                return Error.NotFound("Subject.NotFound", "La asignatura que desea actualizar no fue encontrado.");
            }

            await _ISubjectRepository.UpdateAsync(Domain.Entities.Subject.Create(new Id(request.pId), request.pName, request.Code, request.pCredits, request.pState));

            return Unit.Value;
        }
    }
}
