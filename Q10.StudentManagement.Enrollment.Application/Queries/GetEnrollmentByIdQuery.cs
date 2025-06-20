using ErrorOr;
using MediatR;
using Q10.StudentManagement.Enrollment.Application.Dtos;

namespace Q10.StudentManagement.Enrollment.Application.Queries
{
    public record class GetEnrollmentByIdQuery(Guid pId) : IRequest<ErrorOr<EnrollmentDto>> { }
}
