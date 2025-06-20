using ErrorOr;
using MediatR;
using Q10.StudentManagement.Student.Application.Dtos;

namespace Q10.StudentManagement.Student.Application.Queries
{
    public record GetStudentByIdQuery(Guid pId) : IRequest<ErrorOr<StudentDto>> { }
}
