using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Q10.StudentManagement.Student.Application.Configuration.Validations;

namespace Q10.StudentManagement.Student.Application.Configuration
{
    public static class ApplicationStudentConfiguration
    {
        public static IServiceCollection AddStudentApplication(this IServiceCollection services)
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