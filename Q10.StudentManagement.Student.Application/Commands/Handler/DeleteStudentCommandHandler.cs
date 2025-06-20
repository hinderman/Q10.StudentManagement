using ErrorOr;
using MediatR;
using Q10.StudentManagement.Student.Domain.Interfaces;
using Q10.StudentManagement.Student.Domain.ValueObjects;

namespace Q10.StudentManagement.Student.Application.Commands.Handler
{
    internal sealed class DeleteStudentCommandHandler(IStudentRepository pIStudentRepository) : IRequestHandler<DeleteStudentCommand, ErrorOr<Unit>>
    {
        private readonly IStudentRepository _IStudentRepository = pIStudentRepository ?? throw new ArgumentNullException(nameof(pIStudentRepository));

        public async Task<ErrorOr<Unit>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            if (await _IStudentRepository.GetByIdAsync(new Id(request.pId)) is not Domain.Entities.Student student)
            {
                return Error.NotFound("Student.NotFound", "El usuario que desea eliminar no fue encontrado.");
            }

            await _IStudentRepository.DeleteAsync(new Id(request.pId));

            return Unit.Value;
        }
    }
}
