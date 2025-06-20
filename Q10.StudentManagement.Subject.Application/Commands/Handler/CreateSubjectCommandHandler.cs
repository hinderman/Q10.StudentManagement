using ErrorOr;
using MediatR;
using Q10.StudentManagement.Subject.Domain.Interfaces;
using Q10.StudentManagement.Subject.Domain.ValueObjects;

namespace Q10.StudentManagement.Subject.Application.Commands.Handler
{
    public class CreateSubjectCommandHandler(ISubjectRepository pISubjectRepository) : IRequestHandler<CreateSubjectCommand, ErrorOr<Unit>>
    {
        private readonly ISubjectRepository _ISubjectRepository = pISubjectRepository ?? throw new ArgumentNullException(nameof(pISubjectRepository));

        public async Task<ErrorOr<Unit>> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Guid newGuid = Guid.NewGuid();
                Domain.Entities.Subject objSubject = Domain.Entities.Subject.Create(new Id(newGuid), request.pName, request.pCode, request.pCredits, true);

                await _ISubjectRepository.AddAsync(objSubject);

                return Unit.Value;
            }
            catch (Exception pException)
            {
                return Error.Failure(description: pException.Message);
            }
        }
    }
}
