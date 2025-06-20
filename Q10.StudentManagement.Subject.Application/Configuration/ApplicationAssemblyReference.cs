using System.Reflection;

namespace Q10.StudentManagement.Subject.Application.Configuration
{
    public class AssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
