using Q10.StudentManagement.Student.Domain.ValueObjects;

namespace Q10.StudentManagement.Student.Domain.Entities
{
    public class Student
    {
        public Id Id { get; private set; }
        public Email Email { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }

        private Student(Id pId, Email pEmail, string pName, string pDocument)
        {
            Id = pId ?? throw new ArgumentNullException(nameof(pId));
            Email = pEmail ?? throw new ArgumentNullException(nameof(pEmail));
            Name = pName ?? throw new ArgumentNullException(nameof(pName));
            Document = pDocument ?? throw new ArgumentNullException(nameof(pDocument));
        }

        public static Student Create(Id pId, Email pEmail, string pName, string pDocument)
        {
            return new Student(pId, pEmail, pName, pDocument);
        }
}
