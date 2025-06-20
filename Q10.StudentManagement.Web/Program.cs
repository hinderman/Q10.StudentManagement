using Microsoft.Extensions.Options;
using Q10.StudentManagement.Web.Common;
using Q10.StudentManagement.Web.Interfaces;
using Q10.StudentManagement.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IApiService, ApiService>();
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<ApiSettings>>().Value);
builder.Services.AddScoped<IApiService, ApiService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}");

app.Run();
