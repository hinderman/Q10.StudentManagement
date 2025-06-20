using Q10.StudentManagement.Subject.Domain.ValueObjects;

namespace Q10.StudentManagement.Subject.Domain.Entities
{
    public class Subject
    {
        public Id Id { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public int Credits { get; private set; }
        public bool State { get; private set; }

        private Subject() { }

        private Subject(Id pId, string pName, string pCode, int pCredits, bool pState)
        {
            Id = pId ?? throw new ArgumentNullException(nameof(pId));
            Name = pName ?? throw new ArgumentNullException(nameof(pName));
            Code = pCode ?? throw new ArgumentNullException(nameof(pCode));
            Credits = pCredits;
            State = pState;
        }

        public static Subject Create(Id pId, string pName, string pCode, int pCredits, bool pState)
        {
            return new Subject(pId, pName, pCode, pCredits, pState);
        }
    }
}
