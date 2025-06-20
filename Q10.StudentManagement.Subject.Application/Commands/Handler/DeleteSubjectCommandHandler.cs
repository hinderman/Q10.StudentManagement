using ErrorOr;
using MediatR;
using Q10.StudentManagement.Subject.Domain.Interfaces;
using Q10.StudentManagement.Subject.Domain.ValueObjects;

namespace Q10.StudentManagement.Subject.Application.Commands.Handler
{
    public sealed class DeleteSubjectCommandHandler(ISubjectRepository pISubjectRepository) : IRequestHandler<DeleteSubjectCommand, ErrorOr<Unit>>
    {
        private readonly ISubjectRepository _ISubjectRepository = pISubjectRepository ?? throw new ArgumentNullException(nameof(pISubjectRepository));

        public async Task<ErrorOr<Unit>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _ISubjectRepository.GetByIdAsync(new Id(request.pId)) is not Domain.Entities.Subject subject)
                {
                    return Error.NotFound("Subject.NotFound", "La asignatura que desea eliminar no fue encontrado.");
                }

                await _ISubjectRepository.DeleteAsync(new Id(request.pId));

                return Unit.Value;
            }
            catch (Exception pException)
            {
                return Error.Failure(description: pException.Message);
            }
        }
    }
}
