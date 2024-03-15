using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<CarOwner> carOwners = new List<CarOwner>
        {
        new CarOwner { Name = "John", Age = 23, Car = "BMW", Model = "M5" },
        new CarOwner { Name = "Anna", Age = 30, Car = "Audi", Model = "A4" },
        new CarOwner { Name = "David", Age = 28, Car = "Porsche", Model = "911" },
        new CarOwner { Name = "Emily", Age = 26, Car = "BMW", Model = "X5" },
        new CarOwner { Name = "Mike", Age = 24, Car = "Audi", Model = "A6" },
        new CarOwner { Name = "Jessica", Age = 22, Car = "Porsche", Model = "Cayenne" },
        new CarOwner { Name = "Daniel", Age = 29, Car = "BMW", Model = "X1" },
        new CarOwner { Name = "Olivia", Age = 27, Car = "Audi", Model = "RS7" },
        new CarOwner { Name = "Sophia", Age = 21, Car = "Porsche", Model = "Carrera" },
        new CarOwner { Name = "Stas", Age = 30, Car = "Porsche", Model = "911 GT3 RS" },
        new CarOwner { Name = "Philip", Age = 35, Car = "Audi", Model = "Q7" }
        };
            return View(carOwners);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Porsche()
        {
            return View();
        }
        public IActionResult Audi()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}