using Q10.StudentManagement.Enrollment.Domain.ValueObjects;

namespace Q10.StudentManagement.Enrollment.Domain.Entities
{
    public class Enrollment
    {
        public Id Id { get; private set; }
        public Id StudentId { get; private set; }
        public Id SubjectId { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public bool State { get; private set; }

        private Enrollment() { }

        private Enrollment(Id pId, Id pStudentId, Id pSubjectId, DateTime pRegistrationDate, bool pState)
        {
            Id = pId ?? throw new ArgumentNullException(nameof(pId));
            StudentId = pStudentId ?? throw new ArgumentNullException(nameof(pStudentId));
            SubjectId = pSubjectId ?? throw new ArgumentNullException(nameof(pSubjectId));
            RegistrationDate = pRegistrationDate;
            State = pState;
        }

        public static Enrollment Create(Id pId, Id pStudentId, Id pSubjectId, DateTime pRegistrationDate, bool pState)
        {
            return new Enrollment(pId, pStudentId, pSubjectId, pRegistrationDate, pState);
        }
    }
}
