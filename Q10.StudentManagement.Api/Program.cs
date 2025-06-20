using Q10.StudentManagement.Api.Configuration;
using Q10.StudentManagement.Student.Infrastructure.Configuration;
using Q10.StudentManagement.Student.Application.Configuration;
using Q10.StudentManagement.Api.Middleware;
using Q10.StudentManagement.Subject.Infrastructure.Configuration;
using Q10.StudentManagement.Subject.Application.Configuration;
using Q10.StudentManagement.Enrollment.Infrastructure.Configuration;
using Q10.StudentManagement.Enrollment.Application.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddPresentation()
    .AddStudentInfrastructure(builder.Configuration)
    .AddStudentApplication()
    .AddSubjectInfrastructure(builder.Configuration)
    .AddSubjectApplication()
    .AddEnrollmentInfrastructure(builder.Configuration)
    .AddEnrollmentApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAll");
}

app.UseDeveloperExceptionPage();
app.UseRouting();
app.MapControllers();
app.UseExceptionHandler("/error");
app.UseMiddleware<ApiMiddleware>();
app.UseHttpsRedirection();
app.Run();