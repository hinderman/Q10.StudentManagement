using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Q10.StudentManagement.Enrollment.Application.Configuration.Validations;

namespace Q10.StudentManagement.Enrollment.Application.Configuration
{
    public static class ApplicationEnrollmentConfiguration
    {
        public static IServiceCollection AddEnrollmentApplication(this IServiceCollection services)
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