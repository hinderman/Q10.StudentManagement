using ErrorOr;
using MediatR;
using Q10.StudentManagement.Subject.Application.Dtos;
using Q10.StudentManagement.Subject.Domain.Interfaces;
using Q10.StudentManagement.Subject.Domain.ValueObjects;

namespace Q10.StudentManagement.Subject.Application.Queries.Handler
{
    internal sealed class GetSubjectByIdQueryHandler(ISubjectRepository pISubjectRepository) : IRequestHandler<GetSubjectByIdQuery, ErrorOr<SubjectDto>>
    {
        private readonly ISubjectRepository _ISubjectRepository = pISubjectRepository ?? throw new ArgumentNullException(nameof(pISubjectRepository));


        public async Task<ErrorOr<SubjectDto>> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            if (await _ISubjectRepository.GetByIdAsync(new Id(request.pId)) is not Domain.Entities.Subject subject)
            {
                return Error.NotFound("Subject.NotFound", "No se pudo encontrar la asignatura.");
            }

            return new SubjectDto(subject.Id.pId, subject.Name, subject.Code, subject.Credits, subject.State);
        }
    }
}
