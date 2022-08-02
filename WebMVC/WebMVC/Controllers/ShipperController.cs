using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebMVC.Models;
namespace WebMVC.Controllers
{
    public class ShipperController : Controller
    {
        public IActionResult Index()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            return View();
        }

        public IActionResult Detail(int ID)
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            string sql = "select p.ProductName , p.image, p.price , od.quantity \n"
                   + "from Product p join OrderDetail od on p.ProductID = od.ProductID\n"
                   + "where od.OrderID = " + ID;
            DataTable data = new DAOShipper().getData(sql);
            return View(data);
        }
    }
}
