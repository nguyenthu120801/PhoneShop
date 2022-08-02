using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebMVC.Entity;
using WebMVC.Models;
namespace WebMVC.Controllers
{
    public class ManagerProductController : Controller
    {
        public IActionResult Index(string ID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            List<Product> list;
            // if not choose category
            if (ID == null)
            {
               list = new DAOProduct().GetAllProduct();
            }
            else
            {
                ViewData["cat"] = ID;
                list = new DAOProduct().GetListProduct(ID);
            }
            
            return View(list);
        }
        [HttpPost]
        public IActionResult UpdateSell(int ID , bool sell)
        {
           ViewData["username"] = HttpContext.Session.GetString("username");
           int number = new DAOProduct().UpdateProduct(sell, ID);
            // if update successful
            if (number > 0)
            {
                return RedirectToAction("Index");
            }
            
            return null;
            
        }
        public IActionResult UpdateProduct(int ID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            Product product = new DAOProduct().getProduct(ID);
            return View(product);
        }
        [HttpPost]
        public IActionResult DoUpdateProduct(int ID,string name,string img , int price, int catID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            Product product = new Product()
            {
                ProductID = ID,
                ProductName = name,
                Image = img,
                Price = price,
                CategoryID = catID
            };
            int number = new DAOProduct().UpdateProduct(product);
            // if update successful
            if(number > 0)
            {
                ViewData["mess"] = "Update successful";
                return View("Views/ManagerProduct/UpdateProduct.cshtml",product);
            }
            return null;
        }

        public IActionResult Delete(int ID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            // if product is being bought
            if (new DAOOrderDetail().CheckOrder(ID))
            {
                Product product = new DAOProduct().getProduct(ID);
                ViewData["message"] = "You can't remove product "+ product.ProductName + " because of existing customer buying this product";
                List<Product> list = new DAOProduct().GetAllProduct();
                return View("Views/ManagerProduct/Index.cshtml", list);
            }
            else
            {
              List<OrderDetail> list = new DAOOrderDetail().GetListOrder(ID);
            foreach(OrderDetail detail in list)
            {
                int numberDetail = new DAOOrderDetail().DeleteOrderDetail(detail.OrderID);
                int numberOrder = new DAOOrder().DeleteOrder(detail.OrderID);
            }
            int numberProduct = new DAOProduct().DeleteProduct(ID);
            // if delete successful
            if(numberProduct > 0) {
                ViewData["mess"] = "Remove successful";
                List<Product> listPro = new DAOProduct().GetAllProduct();
                return View("Views/ManagerProduct/Index.cshtml", listPro);
            }
            }
               
            return null;
        }

        public IActionResult Add()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            return View();
        }

        [HttpPost]
        public IActionResult DoAdd(string name, string img, int price, int catID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            Product product = new Product()
            {
                ProductName = name.Trim(),
                Image = img.Trim(),
                Price = price,
                CategoryID = catID,
                isSell = false
            };
            int number = new DAOProduct().AddProduct(product);
            // if update successful
            if (number > 0)
            {
                ViewData["mess"] = "Add successful";
                List<Product> listPro = new DAOProduct().GetAllProduct();
                return View("Views/ManagerProduct/Index.cshtml", listPro);
            }
            return null;
        }

    }
}
