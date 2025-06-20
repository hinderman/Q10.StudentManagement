using ErrorOr;
using MediatR;

namespace Q10.StudentManagement.Student.Application.Commands
{
    public record UpdateStudentCommand(Guid pId, string pEmail, string pName, string pDocument) : IRequest<ErrorOr<Unit>> { }
}
