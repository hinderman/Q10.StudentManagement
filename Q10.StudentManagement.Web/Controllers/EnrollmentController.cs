using Microsoft.AspNetCore.Mvc;

namespace Q10.StudentManagement.Web.Controllers
{
    public class EnrollmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
