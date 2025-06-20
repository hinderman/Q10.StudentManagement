namespace Q10.StudentManagement.Subject.Application.Dtos
{
    public record SubjectDto(Guid pId, string pName, string Code, int pCredits, bool pState);
}
