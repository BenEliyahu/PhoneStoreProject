using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Data;
using PhoneStore.Models;
using PhoneStore.Repositories;
using System.Data;

namespace PhoneStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRepository _service;
        public AdminController(PhoneContext service, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _service = new Repository(service);
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
        public IActionResult AdminPage(int id =1)
        {
            ViewBag.CurrentCategory = _service.PhoneCategoty(id);
            ViewBag.Categories = _service.GetCategories();
            return View(_service.GetPhones().Where(ph => ph.CategoryId == id));
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("AdminPage");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var currentPhone = _service.GetPhones().First(ph => ph.PhoneId == id);
            return View(currentPhone);
        }
        [HttpPost]
        public IActionResult Update(int id, Phone phone)
        {
            if (ModelState.IsValid)
            {
                _service.Update(id, phone);
                return RedirectToAction("AdminPage");
            }
            else
            {
                return Update(id);
            }
        }
        public IActionResult Create(Phone phone)
        {
            if (ModelState.IsValid)
            {
                _service.Create(phone);
                return RedirectToAction("AdminPage");
            }
            else
            {
                return View("Create");
            }
        }
        public IActionResult DeleteComment(int id)
        {
            _service.DeleteComment(id);
            return RedirectToAction("AdminPage");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("AdminPage", "Admin");
                }
                else
                {
                    ViewData["Message"] = "Please try again ";
                    return View();
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Admin");
        }
        public async Task<IActionResult> Register()
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "ben",
            };

            var result = await _userManager.CreateAsync(user, "123qwe!@#QWE");

            if (result.Succeeded)
            {
                return Content("user created successfully");
            }

            return Content("Failed to create user");
        }
    }
}
