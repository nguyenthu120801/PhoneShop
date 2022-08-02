using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WebMVC.Entity;
using WebMVC.Models;
namespace WebMVC.Controllers
{
    public class ManagerAccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            return View();
        }

        public IActionResult UpdateBlocked(string username , bool blocked)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            int number = new DAOAccount().UpdateBlocked(username,blocked);
            // if update successful
           if(number > 0)
           {
              return RedirectToAction("Index");
            }
            return null;
        }

        public IActionResult UpdateRole(string username, string role)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["user"] = username;
            ViewData["role"] = role;
            return View();
        }
        [HttpPost]
        public IActionResult DoUpdateRole(string username, string role,string roleEdit)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            // if change customer to shipper
            if(roleEdit.Equals("Shipper" )&& role.Equals("Customer")){
                Customer customer = new DAOCustomer().getProfile(username);
                int cusID = new DAOCustomer().getCustomerID(username);
                List<Order> list = new DAOOrder().GetListOrder("CustomerID", cusID.ToString());
                // if order is done or cancel or customer not have order
                if (new DAOOrder().CheckOrder(cusID))
                {
                    // loop for traverse all list order
                    foreach (Order order in list) {
                        int numberDetail = new DAOOrderDetail().DeleteOrderDetail(order.OrderID);
                        int numberOrder = new DAOOrder().DeleteOrder(order.OrderID);
                    }
                    int numberCustomer = new DAOCustomer().DeleteCustomer(username);
                    // update role
                    int numberRole = new DAOAccount().UpdateRole(roleEdit, username);
                    // add shipper
                    Shipper shipper = new Shipper() { 
                      active = true,
                      FullName = customer.FullName,
                      Phone = customer.Phone,
                      Email = customer.Email,
                      Gender = customer.Gender,
                      Username = username
                    };
                    int numberShip = new DAOShipper().AddShipper(shipper);
                    // if add successful
                    if(numberShip > 0)
                    {
                        ViewData["mess"] = "Save successful!";
                        ViewData["user"] = username;
                        ViewData["role"] = roleEdit;
                        return View("Views/ManagerAccount/UpdateRole.cshtml");
                    }

                }
                else
                {
                        ViewData["message"] = "You can't change role of this customer to shipper because order of this customer is new or process";
                        ViewData["user"] = username;
                        ViewData["role"] = role;
                        return View("Views/ManagerAccount/UpdateRole.cshtml");
                }
            }
            else
            {
                ViewData["mess"] = "Save successful!";
                ViewData["user"] = username;
                ViewData["role"] = roleEdit;
                return View("Views/ManagerAccount/UpdateRole.cshtml");
            }
            return null;
        }

        // create account
        public IActionResult Create()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            return View();
        }
        [HttpPost]
        public IActionResult DoCreate(string fullName, string phone, string email, int gender, string username, string password)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            Regex regex = new Regex("^[0-9]+$");
            // if phone invalid
            if (!regex.IsMatch(phone) || phone.Length != 10)
            {
                ViewData["message"] = "Phone only number and length is 10";
                return View("Views/ManagerAccount/Create.cshtml");
            }
            // if username exist
            else if (new DAOAccount().CheckUsernameExist(username))
            {
                ViewData["message"] = "Username existed";
                return View("Views/ManagerAccount/Create.cshtml");
            }
            else
            {
                Account account = new Account()
                {
                    Username = username,
                    Password = password,
                    RoleName = "Shipper",
                    IsBlocked = false
                };
                int numberAccount = new DAOAccount().AddAccount(account);
                Shipper shipper = new Shipper()
                {
                    FullName = fullName,
                    Phone = phone,
                    Email = email,
                    active = true,
                    Gender = gender == 1 ? true : false,
                    Username = username
                };
                int number = new DAOShipper().AddShipper(shipper);
                // if add successful
                if (number > 0)
                {
                    ViewData["mess"] = "Create successful";
                    return View("Views/ManagerAccount/Create.cshtml");
                }
            }
            return null;
        }




    }
}
