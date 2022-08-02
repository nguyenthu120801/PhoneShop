using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Entity;
using WebMVC.Models;
namespace WebMVC.Controllers
{
    public class ChangePasswordController : Controller
    {
        public IActionResult Show()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            return View();
        }
        [HttpPost]
        public IActionResult Change(string old, string New, string confirm)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            string username = ViewData["username"].ToString();
            // if old password not correct
            if (!new DAOAccount().CheckAccountValid(username, old))
            {
                @ViewData["message"] = "Your old password not correct";
                return View("Views/ChangePassword/Show.cshtml");
                
            }
            // if new and confirm not the same
            else if (!New.Equals(confirm))
            {
                @ViewData["message"] = "Your confirm password not the same new password";
                return View("Views/ChangePassword/Show.cshtml");
            }
            else
            {
                int number = new DAOAccount().UpdateAccount(username, New);
                // if update successful
                if(number > 0)
                {
                    @ViewData["mess"] = "Change successful";
                    return View("Views/ChangePassword/Show.cshtml");
                }
            }

            return null;
        }
    }
}
