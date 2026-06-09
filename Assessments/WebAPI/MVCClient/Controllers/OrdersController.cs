using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

public class OrdersController : Controller
{
    public async Task<ActionResult> Index()
    {
        HttpClient client = new HttpClient();

        var data = await client.GetStringAsync("http://localhost:5000/api/orders/employee5");

        ViewBag.Data = data;

        return View();
    }
}