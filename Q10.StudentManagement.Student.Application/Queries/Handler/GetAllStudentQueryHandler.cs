using ErrorOr;
using MediatR;
using Q10.StudentManagement.Student.Application.Dtos;
using Q10.StudentManagement.Student.Domain.Interfaces;

namespace Q10.StudentManagement.Student.Application.Queries.Handler
{
    internal sealed class GetAllStudentQueryHandler(IStudentRepository pIStudentRepository) : IRequestHandler<GetAllStudentQuery, ErrorOr<IReadOnlyList<StudentDto>>>
    {
        private readonly IStudentRepository _IStudentRepository = pIStudentRepository ?? throw new ArgumentNullException(nameof(pIStudentRepository));

        public async Task<ErrorOr<IReadOnlyList<StudentDto>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Student> lstStudent = await _IStudentRepository.GetAllAsync();

            return lstStudent.Select(s => new StudentDto(s.Id.pId, s.Email.Value, s.Name, s.Document, s.State)).ToList();
        }
    }
}
