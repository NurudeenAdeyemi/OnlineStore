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
    
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View(_customerService.GetAll());
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerService.FindById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer, bool isCheckout = false)
        {
            if (ModelState.IsValid)
            {
                _customerService.Create(customer);
                return Login(customer.Name, customer.Password, isCheckout);

            }
            else
            {
                ViewBag.Message = "Invalid Details";
                return isCheckout ? RedirectToAction("Checkout", "Order") : RedirectToAction("Index", "Home");
            }

        }
        [Authorize(Roles = "Customer")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerService.FindById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _customerService.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerService.FindById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _customerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult ShoppingCart()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string name, string password, bool isCheckout = false)
        {

            var customer = _customerService.Login(name, password);
            if (customer == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                if (isCheckout)
                {
                    return RedirectToAction("Checkout", "Order");
                }
                return View();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{customer.Name}"),
                    new Claim(ClaimTypes.GivenName, $"{customer.Name} {customer.Name}"),
                    new Claim(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()),
                    new Claim(ClaimTypes.Email, customer.Email),
                    new Claim(ClaimTypes.Role, "Customer"),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return isCheckout ? RedirectToAction("Checkout", "Order") : RedirectToAction("Index", "Home");
            }

        }
    }
}
