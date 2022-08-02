using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Show()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DoLogin(string username , string password)
        {
            // if account valid
            if(new DAOAccount().CheckAccountValid(username, password))
            {
                bool IsBlocked = new DAOAccount().getIsBlocked(username);
                // if account is blocked
                if (IsBlocked)
                {
                    ViewData["message"] = "Your account has been blocked";
                    return View("Views/Login/Show.cshtml");
                }
                else
                {
                    HttpContext.Session.SetString("username",username);
                    string role = new DAOAccount().getRoleName(username);
                    //if role is customer
                    if (role.Equals("Customer"))
                    {
                        return Redirect("/Customer/Index");
                    // if role is shipper
                    }else if (role.Equals("Shipper"))
                    {
                        return Redirect("/Shipper/Index");
                    }
                    else
                    {
                        return Redirect("/Admin/Index");
                    }
                }
            }
            else
            {
                ViewData["message"] = "Username or password incorrect";
                return View("Views/Login/Show.cshtml");
            }
        }
    }
}
