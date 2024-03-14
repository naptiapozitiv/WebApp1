using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MyBag = "Hello World";
            return View();
        }
    }
}
