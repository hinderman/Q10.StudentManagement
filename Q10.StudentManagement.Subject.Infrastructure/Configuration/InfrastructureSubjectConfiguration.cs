using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Q10.StudentManagement.Subject.Domain.Interfaces;
using Q10.StudentManagement.Subject.Infrastructure.Persistence.DataBaseContext;
using Q10.StudentManagement.Subject.Infrastructure.Repositories;

namespace Q10.StudentManagement.Subject.Infrastructure.Configuration
{
    public static class InfrastructureSubjectConfiguration
    {
        public static IServiceCollection AddSubjectInfrastructure(this IServiceCollection pIServiceCollection, IConfiguration pIConfiguration)
        {
            pIServiceCollection.AddDbContext<SubjectDataBaseContext>(options => options.UseSqlServer(pIConfiguration.GetConnectionString("DataBaseConnection")));
            pIServiceCollection.AddScoped<ISubjectRepository, SubjectRepository>();

            return pIServiceCollection;
        }
    }
}
