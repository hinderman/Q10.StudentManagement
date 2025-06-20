using Microsoft.AspNetCore.Mvc;
using Q10.StudentManagement.Web.Interfaces;
using Q10.StudentManagement.Web.Models.Students;

namespace Q10.StudentManagement.Web.Controllers
{
    public class StudentController(IApiService pIApiService, ILogger<StudentController> pILogger) : Controller
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
                _ILogger.LogError(ex, "Error al obtener la lista de estudiantes");
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View(new StudentViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                bool result = await _IApiService.PostAsync<StudentViewModel>("Student", model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al crear el estudiante: " + ex.Message);
                return View(model);
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            StudentViewModel responce = await _IApiService.GetAsync<StudentViewModel>("Student/"+id);
            return View(responce);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(StudentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                bool result = await _IApiService.PutAsync<StudentViewModel>("Student", model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al editar el estudiante: " + ex.Message);
                return View(model);
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        
        {
            try
            {
                bool deleteStudent = await _IApiService.DeleteAsync<StudentViewModel>("Student/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex, "Error al obtener la lista de estudiantes");
                return View("Error");
            }
        }
    }
}
