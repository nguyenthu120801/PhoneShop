using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using WebMVC.Entity;
using WebMVC.Models;
namespace WebMVC.Controllers
{
    public class ManagerOrderController : Controller
    {
        public IActionResult Index(string status)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            List<Order> list;
            // if not choose status
            if (status == null)
            {
         
                 list = new DAOOrder().GetAllOrder();
            }
            else
            {
                 list = new DAOOrder().GetListOrder(status);
                  ViewData["status"] = status;
            }
            return View(list);
        }
        
        public IActionResult View(int ID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            string sql = "select p.ProductName , p.image, p.price , od.quantity \n"
                   + "from Product p join OrderDetail od on p.ProductID = od.ProductID\n"
                   + "where od.OrderID = " + ID;
            DataTable data = new DAOOrder().getData(sql);
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateStatus(string status , int ID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            int number = new DAOOrder().UpdateStatus(status, ID);
            // if update successful
            if(number > 0)
            {
                return RedirectToAction("Index");
            }
            return null;
        }
        [HttpPost]
        public IActionResult UpdateShipper(string ShipID , int OrderID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            int number = new DAOOrder().UpdateShipID(ShipID, OrderID);
            // if update successful
            if (number > 0)
            {
                return RedirectToAction("Index");
            }
            return null;
        }

        public IActionResult UpdateShippedDate(string date,int ID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            ViewData["date"] = date;
            ViewData["ID"] = ID;
            return View();
        }

        [HttpPost]
        public IActionResult DoUpdate(string date, int ID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            int number = new DAOOrder().UpdateShipDate(date, ID);
            // if update successful
            if( number > 0)
            {
                ViewData["date"] = date;
                ViewData["ID"] = ID;
                ViewData["mess"] = "Update successful";
                return View("Views/ManagerOrder/UpdateShippedDate.cshtml");
            }
            return null;
        }

        public IActionResult Delete(int ID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            int numberDetail = new DAOOrderDetail().DeleteOrderDetail(ID);
            int numberOrder = new DAOOrder().DeleteOrder(ID);
            // if delete successful
            if(numberOrder > 0)
            {
                ViewData["mess"] = "Remove successful";
                List<Order> list = new DAOOrder().GetAllOrder();
                return View("Views/ManagerOrder/Index.cshtml",list);
            }
            return null;
        }

    }
}
