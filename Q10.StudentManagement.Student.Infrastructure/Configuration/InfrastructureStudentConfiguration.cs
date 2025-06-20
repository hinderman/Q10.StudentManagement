using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Q10.StudentManagement.Student.Domain.Interfaces;
using Q10.StudentManagement.Student.Infrastructure.Persistence.DataBaseContext;
using Q10.StudentManagement.Student.Infrastructure.Repositories;

namespace Q10.StudentManagement.Student.Infrastructure.Configuration
{
    public static class InfrastructureStudentConfiguration
    {
        public static IServiceCollection AddStudentInfrastructure(this IServiceCollection pIServiceCollection, IConfiguration pIConfiguration)
        {
            pIServiceCollection.AddDbContext<StudentDataBaseContext>(options => options.UseSqlServer(pIConfiguration.GetConnectionString("DataBaseConnection")));
            pIServiceCollection.AddScoped<IStudentRepository, StudentRepository>();

            return pIServiceCollection;
        }
    }
}
