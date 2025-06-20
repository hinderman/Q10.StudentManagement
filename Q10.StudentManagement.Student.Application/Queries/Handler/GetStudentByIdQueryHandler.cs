using ErrorOr;
using MediatR;
using Q10.StudentManagement.Student.Application.Dtos;
using Q10.StudentManagement.Student.Domain.Interfaces;
using Q10.StudentManagement.Student.Domain.ValueObjects;

namespace Q10.StudentManagement.Student.Application.Queries.Handler
{
    internal sealed class GetStudentByIdQueryHandler(IStudentRepository pIStudentRepository) : IRequestHandler<GetStudentByIdQuery, ErrorOr<StudentDto>>
    {
        private readonly IStudentRepository _IStudentRepository = pIStudentRepository ?? throw new ArgumentNullException(nameof(pIStudentRepository));

        public async Task<ErrorOr<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            if (await _IStudentRepository.GetByIdAsync(new Id(request.pId)) is not Domain.Entities.Student student)
            {
                return Error.NotFound("Student.NotFound", "No se pudo encontrar el estudiante.");
            }

            return new StudentDto(student.Id.pId, student.Email.Value, student.Name, student.Document, student.State);
        }
    }
}
