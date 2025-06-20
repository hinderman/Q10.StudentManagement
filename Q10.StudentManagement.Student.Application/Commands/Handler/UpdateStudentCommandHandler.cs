using ErrorOr;
using MediatR;
using Q10.StudentManagement.Student.Domain.Interfaces;
using Q10.StudentManagement.Student.Domain.ValueObjects;

namespace Q10.StudentManagement.Student.Application.Commands.Handler
{
    internal sealed class UpdateStudentCommandHandler(IStudentRepository pIStudentRepository) : IRequestHandler<UpdateStudentCommand, ErrorOr<Unit>>
    {
        private readonly IStudentRepository _IStudentRepository = pIStudentRepository ?? throw new ArgumentNullException(nameof(pIStudentRepository));

        public async Task<ErrorOr<Unit>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            if (await _IStudentRepository.GetByIdAsync(new Id(request.pId)) is not Domain.Entities.Student student)
            {
                return Error.NotFound("Student.NotFound", "El usuario que desea actualizar no fue encontrado.");
            }

            if (Email.Create(request.pEmail) is not Email email)
            {
                return Error.NotFound("Student.Email", "Email no valido.");
            }

            await _IStudentRepository.UpdateAsync(Domain.Entities.Student.Create(new Id(request.pId), email, request.pName, request.pDocument, true));

            return Unit.Value;
        }
    }
}
