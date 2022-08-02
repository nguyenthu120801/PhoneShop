using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebMVC.Entity;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Show()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoRegister(string fullName,string phone , string email , int gender ,string username, string password)
        {
            Regex regex = new Regex("^[0-9]+$");
            // if phone invalid
            if (!regex.IsMatch(phone) || phone.Length !=10)
            {
                ViewData["message"] = "Phone only number and length is 10";
                return View("Views/Register/Show.cshtml");
            }
            // if username exist
            else if(new DAOAccount().CheckUsernameExist(username))
            {
                ViewData["message"] = "Username existed";
                return View("Views/Register/Show.cshtml");
            }
            else
            {
                Account account = new Account()
                {
                    Username = username,
                    Password = password,
                    RoleName = "Customer",
                    IsBlocked = false
                };
                int numberAccount = new DAOAccount().AddAccount(account);
                Customer customer = new Customer()
                {
                    FullName = fullName,
                    Phone = phone,
                    Email = email,
                    Gender = gender == 1 ? true: false,
                    Username = username
                };
                int numberCus = new DAOCustomer().AddCustomer(customer);
                // if add successful
                if(numberCus > 0)
                {
                    ViewData["mess"] = "Register successful";
                    return View("Views/Register/Show.cshtml");
                }
            }
            return null;
        }
    }
}
