using ErrorOr;
using MediatR;

namespace Q10.StudentManagement.Subject.Application.Commands
{
    public record DeleteSubjectCommand(Guid pId) : IRequest<ErrorOr<Unit>> { }
}
