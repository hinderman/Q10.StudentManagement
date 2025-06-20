namespace Q10.StudentManagement.Student.Application.Dtos
{
    public record StudentDto(Guid pId, string pEmail, string pName, string pDocument, bool pState);
}
