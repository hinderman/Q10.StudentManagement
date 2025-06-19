using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Q10.StudentManagement.Student.Domain.Interfaces;
using Q10.StudentManagement.Student.Infrastructure.Repositories;

namespace Q10.StudentManagement.Student.Infrastructure.Configuration
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection pIServiceCollection, IConfiguration pIConfiguration)
        {
            pIServiceCollection.AddScoped<IStudentRepository, StudentRepository>();

            return pIServiceCollection;
        }
    }
}
