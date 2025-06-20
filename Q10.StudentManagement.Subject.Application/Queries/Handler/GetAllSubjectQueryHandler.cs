using ErrorOr;
using MediatR;
using Q10.StudentManagement.Subject.Application.Dtos;
using Q10.StudentManagement.Subject.Domain.Interfaces;

namespace Q10.StudentManagement.Subject.Application.Queries.Handler
{
    internal sealed class GetAllSubjectQueryHandler(ISubjectRepository pISubjectRepository) : IRequestHandler<GetAllSubjectQuery, ErrorOr<IReadOnlyList<SubjectDto>>>
    {
        private readonly ISubjectRepository _ISubjectRepository = pISubjectRepository ?? throw new ArgumentNullException(nameof(pISubjectRepository));
        async Task<ErrorOr<IReadOnlyList<SubjectDto>>> IRequestHandler<GetAllSubjectQuery, ErrorOr<IReadOnlyList<SubjectDto>>>.Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Subject> lstSubject = await _ISubjectRepository.GetAllAsync();

            return lstSubject.Select(s => new SubjectDto(s.Id.pId, s.Name, s.Code, s.Credits, s.State)).ToList();
        }
    }
}
