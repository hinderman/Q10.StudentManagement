using ErrorOr;
using MediatR;
using Q10.StudentManagement.Enrollment.Application.Dtos;

namespace Q10.StudentManagement.Enrollment.Application.Queries
{
    public record GetAllEnrollmentQuery : IRequest<ErrorOr<IReadOnlyList<EnrollmentDto>>> { }
}
