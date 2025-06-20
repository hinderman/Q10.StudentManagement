using ErrorOr;
using MediatR;

namespace Q10.StudentManagement.Enrollment.Application.Commands
{
    public record DeleteEnrollmentCommand(Guid pId) : IRequest<ErrorOr<Unit>> { }
}
