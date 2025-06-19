using AutoMapper;
using ErrorOr;
using MediatR;
using Q10.StudentManagement.Student.Application.Dtos;
using Q10.StudentManagement.Student.Domain.Interfaces;

namespace Q10.StudentManagement.Student.Application.Queries.Handler
{
    internal sealed class GetAllStudentQueryHandler(IStudentRepository pIStudentRepository, IMapper pIMapper) : IRequestHandler<GetAllStudentQuery, ErrorOr<IReadOnlyList<StudentDto>>>
    { 
        private readonly IStudentRepository _IStudentRepository = pIStudentRepository ?? throw new ArgumentNullException(nameof(pIStudentRepository));
        private readonly IMapper _IMapper = pIMapper ?? throw new ArgumentNullException(nameof(pIMapper));

        public async Task<ErrorOr<IReadOnlyList<StudentDto>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            List<StudentDto> studentDtos = _IMapper.Map<List<StudentDto>>(await _IStudentRepository.GetAllAsync());

            return studentDtos;
        }
    }
}
