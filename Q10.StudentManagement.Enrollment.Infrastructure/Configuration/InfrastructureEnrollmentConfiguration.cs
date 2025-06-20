using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Q10.StudentManagement.Enrollment.Domain.Interfaces;
using Q10.StudentManagement.Enrollment.Infrastructure.Persistence.DataBaseContext;
using Q10.StudentManagement.Enrollment.Infrastructure.Repositories;

namespace Q10.StudentManagement.Enrollment.Infrastructure.Configuration
{
    public static class InfrastructureEnrollmentConfiguration
    {
        public static IServiceCollection AddEnrollmentInfrastructure(this IServiceCollection pIServiceCollection, IConfiguration pIConfiguration)
        {
            pIServiceCollection.AddDbContext<EnrollmentDataBaseContext>(options => options.UseSqlServer(pIConfiguration.GetConnectionString("DataBaseConnection")));
            pIServiceCollection.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

            return pIServiceCollection;
        }
    }
}
