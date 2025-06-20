using ErrorOr;
using MediatR;
using Q10.StudentManagement.Subject.Application.Dtos;

namespace Q10.StudentManagement.Subject.Application.Queries
{
    public record GetAllSubjectQuery : IRequest<ErrorOr<IReadOnlyList<SubjectDto>>> { }
}
