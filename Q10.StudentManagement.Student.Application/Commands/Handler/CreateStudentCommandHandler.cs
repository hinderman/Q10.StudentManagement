using ErrorOr;
using MediatR;
using Q10.StudentManagement.Student.Domain.Interfaces;
using Q10.StudentManagement.Student.Domain.ValueObjects;

namespace Q10.StudentManagement.Student.Application.Commands.Handler
{
    internal sealed class CreateStudentCommandHandler(IStudentRepository pIStudentRepository) : IRequestHandler<CreateStudentCommand, ErrorOr<Unit>>
    {
        private readonly IStudentRepository _IStudentRepository = pIStudentRepository ?? throw new ArgumentNullException(nameof(pIStudentRepository));

        public async Task<ErrorOr<Unit>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            if (Email.Create(request.pEmail) is not Email email)
            {
                return Error.NotFound("Student.Email", "Email no valido.");
            }

            Guid newGuid = Guid.NewGuid();
            Domain.Entities.Student objStudent = Domain.Entities.Student.Create(new Id(newGuid), email, request.pName,request.pDocument, true);

            await _IStudentRepository.AddAsync(objStudent);

            return Unit.Value;
        }
    }
}
