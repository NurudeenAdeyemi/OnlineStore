using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStore.Models;
using OnlineStore.Service;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService _itemService;

        public HomeController(IItemService itemService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _itemService = itemService;
        }

      

        public IActionResult Index()
        {
            var items = _itemService.GetAll();
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Faqs()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            IEnumerable<Item> items = _itemService.Search(search);
            return View("Index", items);
        }
        public IActionResult ViewCart()
        {
            return View();
        }
    }
}
