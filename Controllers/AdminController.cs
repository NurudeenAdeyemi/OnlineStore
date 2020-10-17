using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OnlineStore.Service;

namespace OnlineStore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
        {
            private readonly IAdminService _adminService;
            public AdminController(IAdminService adminService)
            {
                _adminService = adminService;
            }


            public IActionResult Index()
            {
                return View(_adminService.GetAll());
            }

            public IActionResult Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var admin = _adminService.FindById(id.Value);
                if (admin == null)
                {
                    return NotFound();
                }

                return View(admin);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Admin admin)
            {
                if (ModelState.IsValid)
                {
                    _adminService.Create(admin);

                }
                return RedirectToAction("Index", "Admin");
            }

            [HttpGet]
            public IActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var admin = _adminService.FindById(id.Value);
                if (admin == null)
                {
                    return NotFound();
                }
                return View(admin);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(int id, Admin admin)
            {
                if (id != admin.AdminId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _adminService.Update(admin);
                    return RedirectToAction(nameof(Index));
                }
                return View(admin);
            }


            public IActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var admin = _adminService.FindById(id.Value);
                if (admin == null)
                {
                    return NotFound();
                }

                return View(admin);
            }


            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {

                _adminService.Delete(id);
                return RedirectToAction(nameof(Index));
            }




            [HttpGet]
            public IActionResult Logout()
            {

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login");
            }

            [HttpGet]
            [AllowAnonymous]
            public IActionResult Login()
            {

                return View();
            }

            [HttpPost]
            [AllowAnonymous]
            public IActionResult Login(string email, string password)
            {

                var admin = _adminService.Login(email, password);
                if (admin == null)
                {
                    ViewBag.Message = "Invalid Email/Password";
                    return View();
                }
                else
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{admin.FirstName}"),
                    new Claim(ClaimTypes.GivenName, $"{admin.FirstName} {admin.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, admin.AdminId.ToString()),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authenticationProperties = new AuthenticationProperties();
                    var principal = new ClaimsPrincipal(claimsIdentity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                    return RedirectToAction("Dashboard", "Admin");
                }


            }
            public IActionResult Dashboard()
            {
                return View();
            }
        }
}
