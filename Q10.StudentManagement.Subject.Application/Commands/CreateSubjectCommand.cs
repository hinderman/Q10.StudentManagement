using ErrorOr;
using MediatR;

namespace Q10.StudentManagement.Subject.Application.Commands
{
    public record CreateSubjectCommand(Guid pId, string pName, string Code, int pCredits, bool pState) : IRequest<ErrorOr<Unit>> { }
}
