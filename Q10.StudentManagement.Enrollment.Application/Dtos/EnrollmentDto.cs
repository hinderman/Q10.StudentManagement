namespace Q10.StudentManagement.Enrollment.Application.Dtos
{
    public record EnrollmentDto(Guid pId, Guid pStudentId, Guid pSubjectId, DateTime pRegistrationDate, bool pState);
}
