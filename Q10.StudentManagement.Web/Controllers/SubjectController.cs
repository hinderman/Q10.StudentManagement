using Microsoft.AspNetCore.Mvc;
using Q10.StudentManagement.Web.Interfaces;
using Q10.StudentManagement.Web.Models.Subject;

namespace Q10.StudentManagement.Web.Controllers
{
    public class SubjectController(IApiService pIApiService, ILogger<SubjectController> pILogger) : Controller
    {
        private readonly IApiService _IApiService = pIApiService ?? throw new ArgumentNullException(nameof(pIApiService));
        private readonly ILogger<SubjectController> _ILogger = pILogger ?? throw new ArgumentNullException(nameof(pILogger));

        public async Task<ActionResult> Index()
        {
            try
            {
                IEnumerable<SubjectViewModel> responce = await _IApiService.GetAsync<IEnumerable<SubjectViewModel>>("Subject");
                return View(responce);
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex, "Error al obtener la lista de asignaturas");
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View(new SubjectViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                bool result = await _IApiService.PostAsync<SubjectViewModel>("Subject", model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al crear la asignatura: " + ex.Message);
                return View(model);
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            SubjectViewModel responce = await _IApiService.GetAsync<SubjectViewModel>("Subject/" + id);
            return View(responce);
        }

        [HttpPost]
        public ActionResult Edit(SubjectViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                bool result = _IApiService.Put<SubjectViewModel>("Subject", model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al editar el asignaturas: " + ex.Message);
                return View(model);
            }
        }

        public ActionResult Delete(Guid id)

        {
            try
            {
                bool deleteSubject = _IApiService.Delete<SubjectViewModel>("Subject/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex, "Error al obtener la lista de asignaturas");
                return View("Error");
            }
        }
    }
}
