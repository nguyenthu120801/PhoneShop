using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Entity;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ManagerShipperController : Controller
    {
        public IActionResult Index()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            return View();
        }

        public IActionResult UpdateActive(int ID ,bool active)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            int number = new DAOShipper().UpdateShipper(active, ID);
            // if update successful
            if(number > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
