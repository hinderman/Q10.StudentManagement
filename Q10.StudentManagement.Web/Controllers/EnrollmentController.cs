using Microsoft.AspNetCore.Mvc;
using Q10.StudentManagement.Web.Interfaces;
using Q10.StudentManagement.Web.Models.Students;

namespace Q10.StudentManagement.Web.Controllers
{
    public class EnrollmentController(IApiService pIApiService, ILogger<StudentController> pILogger) : Controller
    {
        private readonly IApiService _IApiService = pIApiService ?? throw new ArgumentNullException(nameof(pIApiService));
        private readonly ILogger<StudentController> _ILogger = pILogger ?? throw new ArgumentNullException(nameof(pILogger));

        public async Task<ActionResult> Index()
        {
            try
            {
                IEnumerable<StudentViewModel> responce = await _IApiService.GetAsync<IEnumerable<StudentViewModel>>("Student");
                return View(responce);
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex, "Error al obtener la lista de asignaturas");
                return View("Error");
            }
        }
    }
}
