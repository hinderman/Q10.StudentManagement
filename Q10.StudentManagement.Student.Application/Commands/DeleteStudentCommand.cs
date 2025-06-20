using ErrorOr;
using MediatR;

namespace Q10.StudentManagement.Student.Application.Commands
{
    public record DeleteStudentCommand(Guid pId) : IRequest<ErrorOr<Unit>> { }
}
