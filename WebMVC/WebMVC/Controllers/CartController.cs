using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebMVC.Entity;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Add(string name)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            string quantity = HttpContext.Session.GetString(name);
            // if not buy 
            if(quantity == null)
            {
                quantity = "1";
                HttpContext.Session.SetString(name, quantity);
            }
            else
            {
                HttpContext.Session.SetString(name, (Convert.ToInt32(quantity) + 1).ToString());
            }
            return Redirect("/Customer/Index");
        }

        public IActionResult Show()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            Dictionary<string, int> dic = new Dictionary<string, int>();
            // get all product
            List<Product> list = new DAOProduct().GetAllProduct();
            // loop for traverse all product
            foreach (Product product in list)
            {                               
                string quantity = HttpContext.Session.GetString(product.ProductName.Trim());
                // if user bought product
                if (quantity != null)
                {
                    dic.Add(product.ProductName, Convert.ToInt32(quantity));
                }
                
            }
            return View(dic);
        }
        public IActionResult Update(string name , int quantity)
        {
            if(quantity >0)
            {
             HttpContext.Session.SetString(name, quantity.ToString());
            }     
            return RedirectToAction("Show");
        }

        public IActionResult Remove(string name)
        {
            HttpContext.Session.Remove(name);
            return RedirectToAction("Show");
        }

        // check list cart empty
        public bool CheckListCartEmpty()
        {
            int count = 0;
            // get all product
            List<Product> list = new DAOProduct().GetAllProduct();
            // loop for traverse all product
            foreach (Product product in list)
            {
                string quantity = HttpContext.Session.GetString(product.ProductName.Trim());
                // if user bought product
                if (quantity != null)
                {
                    count++;
                }
            }
            return count == 0;
        }
        public IActionResult CheckOut()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            // if list cart empty
            if (CheckListCartEmpty())
            {
                ViewData["message"] = "You can't check out when your cart is empty";
                Dictionary<string, int> dic = new Dictionary<string, int>();
                return View("Views/Cart/Show.cshtml" ,dic);
            }
            else
            {
                Dictionary<string, int> dic = new Dictionary<string, int>();
                // get all product
                List<Product> list = new DAOProduct().GetAllProduct();
                // loop for traverse all product
                foreach (Product product in list)
                {
                    string quantity = HttpContext.Session.GetString(product.ProductName.Trim());
                    // if user bought product
                    if (quantity != null)
                    {
                        dic.Add(product.ProductName, Convert.ToInt32(quantity));
                    }
                }
                return View(dic);
            }
            
        }
        [HttpPost]
        public IActionResult DoCheckOut(int sum , string address)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToString("yyyy-MM-dd");
            string username = ViewData["username"].ToString();
            int ID = new DAOCustomer().getCustomerID(username);
            Order order = new Order()
            {
                CustomerID = ID,
                status = "New",
                TotalPrice = sum,
                OrderDate = date,
                ShipID = null,
                ShippedDate = null,
                Address = address              
            };
            int numberOrder = new DAOOrder().AddOrder(order);
            int orderID = new DAOOrder().getOrderID();
            int detailID = 1;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            // get all product
            List<Product> list = new DAOProduct().GetAllProduct();
            // loop for traverse all product
            foreach (Product product in list)
            {
                string quantity = HttpContext.Session.GetString(product.ProductName.Trim());
                // if user bought product
                if (quantity != null)
                {
                    dic.Add(product.ProductName, Convert.ToInt32(quantity));
                }
            }
            // loop for traverse through all dic
            foreach(string name in dic.Keys)
            {
                int quantity = dic[name];
                int productID = new DAOProduct().getProductID(name);
                int price = new DAOProduct().getPrice(name);
                OrderDetail detail = new OrderDetail()
                {
                     OrderID = orderID,
                     DetailID = detailID,
                     ProductID = productID,
                     Price = price,
                     Quantity = quantity
                };
                int numberDetail = new DAOOrderDetail().AddOrderDetail(detail);
                detailID++;
            }
            // loop for traverse all product
            foreach (Product product in list)
            {
                HttpContext.Session.Remove(product.ProductName.Trim());
            }
            ViewData["address"] = address;
            ViewData["message"] = "Check out successful";
            return View("Views/Cart/CheckOut.cshtml",dic);
        }

    }
}
