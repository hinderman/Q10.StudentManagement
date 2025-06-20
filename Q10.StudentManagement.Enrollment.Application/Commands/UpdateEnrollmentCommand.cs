using ErrorOr;
using MediatR;

namespace Q10.StudentManagement.Enrollment.Application.Commands
{
    public record UpdateEnrollmentCommand(Guid pId, Guid pStudentId, Guid pSubjectId, DateTime pRegistrationDate, bool pState) : IRequest<ErrorOr<Unit>> { }
}
