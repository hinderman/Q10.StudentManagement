using System.Reflection;

namespace Q10.StudentManagement.Api.Configuration
{
    public class ApiAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(ApiAssemblyReference).Assembly;
    }
}
