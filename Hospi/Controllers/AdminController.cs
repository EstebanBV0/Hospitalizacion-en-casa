using Microsoft.AspNetCore.Mvc;

namespace HospiEnCasa.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
