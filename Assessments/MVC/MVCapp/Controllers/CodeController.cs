using System.Linq;
using System.Web.Mvc;
using MVCapp.Models;

namespace YourProjectName.Controllers
{
    public class CodeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GermanCustomers()
        {
            var data = db.Customers
                         .Where(c => c.Country == "Germany")
                         .ToList();

            return View(data);
        }

        public ActionResult CustomerByOrder()
        {
            var data = db.Orders
                         .Where(o => o.OrderID == 10248)
                         .Select(o => o.Customer)
                         .FirstOrDefault();

            return View(data);
        }
    }
}