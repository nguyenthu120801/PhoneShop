using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebMVC.Entity;
using WebMVC.Models;
namespace WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index(string ID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            List<Product> listProduct;
            // if not choose category
            if (ID == null)
            {
                // get all product
                listProduct = new DAOProduct().GetAllProduct();
            }
            else
            {
                // get list product based on category
                listProduct = new DAOProduct().GetListProduct(ID);
            }
            return View(listProduct);
        }
    }
}
