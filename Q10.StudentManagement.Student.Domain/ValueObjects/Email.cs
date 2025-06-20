using System.Text.RegularExpressions;

namespace Q10.StudentManagement.Student.Domain.ValueObjects
{
    public partial record Email
    {
        private const string Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public string Value { get; init; }
        private Email(string pValue) => Value = pValue;

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();

        public static Email? Create(string pValue)
        {
            if (string.IsNullOrEmpty(pValue) || !EmailRegex().IsMatch(pValue))
            {
                return null;
            }

            return new Email(pValue.ToLower());
        }
    }
}
