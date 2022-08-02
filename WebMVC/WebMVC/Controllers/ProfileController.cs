using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebMVC.Entity;
using WebMVC.Models;
namespace WebMVC.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Show()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            string username = ViewData["username"].ToString();
            string role = new DAOAccount().getRoleName(username);
            // if role is customer
            if (role.Equals("Customer"))
            {
                Customer customer = new DAOCustomer().getProfile(username);
                return View("Views/Profile/Customer.cshtml", customer);
            }
            else
            {
                Shipper shipper = new DAOShipper().getProfile(username);
                return View("Views/Profile/Shipper.cshtml", shipper);
            }
        }
        public IActionResult Update(string fullName , int gender ,string phone , string email)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            string username = ViewData["username"].ToString();
            string role = new DAOAccount().getRoleName(username); 
            // if customer
            if (role.Equals("Customer"))
            {
               Customer customer =new Customer()
               {
                FullName = fullName,
                Gender = gender == 1 ?true :false,
                Phone = phone,
                Email = email,
                Username = username
                };
                Regex regex = new Regex("^[0-9]+$");
                // if phone invalid
                if (!regex.IsMatch(phone) || phone.Length != 10)
                {
                    ViewData["message"] = "Phone only number and length is 10";
                    return View("Views/Profile/Customer.cshtml" , customer);
                }
                else
                {
                    int number = new DAOCustomer().UpdateCustomer(customer);
                    // if update successful
                    if(number > 0)
                    {
                        ViewData["mess"] = "Change successful";
                        return View("Views/Profile/Customer.cshtml", customer);
                    }
                }
            }
            else
            {
                Shipper shipper = new Shipper()
                {
                    FullName = fullName,
                    Gender = gender == 1 ? true : false,
                    Phone = phone,
                    Email = email,
                    Username = username
                };
                Regex regex = new Regex("^[0-9]+$");
                // if phone invalid
                if (!regex.IsMatch(phone) || phone.Length != 10)
                {
                    ViewData["message"] = "Phone only number and length is 10";
                    return View("Views/Profile/Shipper.cshtml", shipper);
                }
                else
                {
                    int number = new DAOShipper().UpdateShipper(shipper);
                    // if update successful
                    if (number > 0)
                    {
                        ViewData["mess"] = "Change successful";
                        return View("Views/Profile/Shipper.cshtml", shipper);
                    }
                }
            }
            return null;
        }

    }
}
