using ErrorOr;
using MediatR;
using Q10.StudentManagement.Subject.Application.Dtos;

namespace Q10.StudentManagement.Subject.Application.Queries
{
    public record GetSubjectByIdQuery(Guid pId) : IRequest<ErrorOr<SubjectDto>> { }
}
