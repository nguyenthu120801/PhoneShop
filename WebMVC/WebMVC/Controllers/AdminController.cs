using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            return View();
        }
    }
}
