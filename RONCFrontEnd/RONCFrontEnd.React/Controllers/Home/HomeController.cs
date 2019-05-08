using Microsoft.AspNetCore.Mvc;

namespace RONCFrontEnd.React
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}