using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Q10.StudentManagement.Subject.Application.Configuration.Validations;

namespace Q10.StudentManagement.Subject.Application.Configuration
{
    public static class ApplicationSubjectConfiguration
    {
        public static IServiceCollection AddSubjectApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblyContaining<AssemblyReference>();
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationsBehaviors<,>));
            services.AddValidatorsFromAssemblyContaining<AssemblyReference>();

            return services;
        }
    }
}
