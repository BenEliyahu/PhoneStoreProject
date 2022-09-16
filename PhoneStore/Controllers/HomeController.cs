using Microsoft.AspNetCore.Mvc;
using PhoneStore.Data;
using PhoneStore.Models;
using PhoneStore.Repositories;
using System.Diagnostics;

namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository _service;
        public HomeController(ILogger<HomeController> logger,PhoneContext service)
        {
            _logger = logger;
            _service = new Repository(service);
        }

        public IActionResult Index()
        {
            return View(_service.GetPhones().OrderByDescending(ph => ph.Comments.Count).Take(2));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}