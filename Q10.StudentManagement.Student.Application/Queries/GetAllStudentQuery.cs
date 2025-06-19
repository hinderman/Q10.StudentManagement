using ErrorOr;
using MediatR;
using Q10.StudentManagement.Student.Application.Dtos;

namespace Q10.StudentManagement.Student.Application.Queries
{
    public record GetAllStudentQuery : IRequest<ErrorOr<IReadOnlyList<StudentDto>>> { }
}
