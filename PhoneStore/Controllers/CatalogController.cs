using Microsoft.AspNetCore.Mvc;
using PhoneStore.Data;
using PhoneStore.Models;
using PhoneStore.Repositories;

namespace PhoneStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRepository _service;
        public CatalogController(PhoneContext service)
        {
            _service = new Repository(service);
        }
        public IActionResult Index(int id = 1)
        {
            ViewBag.CurrentCategory = _service.PhoneCategoty(id);
            ViewBag.Categories = _service.GetCategories();
            return View(_service.GetPhones().Where(ph => ph.CategoryId == id));
        }
        public IActionResult Details(int id)
        {
            var phone = _service.GetPhones().First(ph => ph.PhoneId == id);
            return View(phone);
        }
        [HttpPost]
        public IActionResult Details(int Phone, string CommentMessage)
        {
            if (ModelState.IsValid)
            {
                _service.AddComment(Phone, CommentMessage);
                return RedirectToAction("Details");
            }
            return RedirectToAction("Details");
        }
    }
}
