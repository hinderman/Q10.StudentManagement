using Microsoft.OpenApi.Models;
using Q10.StudentManagement.Api.Middleware;

namespace Q10.StudentManagement.Api.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddPresentation(this IServiceCollection pIServiceCollection)
        {
            pIServiceCollection.AddControllers();
            pIServiceCollection.AddEndpointsApiExplorer();
            pIServiceCollection.AddSwaggerGen();
            pIServiceCollection.AddTransient<ApiMiddleware>();

            pIServiceCollection.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Prueba tecnica Q10",
                    Description = "Api para la prueba técnica de Q10 implementando arquitectura limpia en.Net 8 y buenas prácticas de programación"
                });
            });

            return pIServiceCollection;
        }
    }
}
