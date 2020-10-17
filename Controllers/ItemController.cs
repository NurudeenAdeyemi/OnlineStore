using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Models;
using OnlineStore.Service;

namespace OnlineStore.Controllers
{
    
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryService _categoryService;

        public ItemController(IItemService itemService, IWebHostEnvironment webHostEnvironmrnt, ICategoryService categoryService)
        {
            _itemService = itemService;
            _webHostEnvironment = webHostEnvironmrnt;
            _categoryService = categoryService;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View(_itemService.GetAll());
        }

        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _itemService.FindById(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Create()
        {
            List<Category> categories = _categoryService.GetAll();
            List<SelectListItem> listAItems = new List<SelectListItem>();
            foreach (Category category in categories)
            {
                SelectListItem item = new SelectListItem(category.CategoryName, category.ID.ToString());
                listAItems.Add(item);
            }

            ViewBag.Categories = listAItems;
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    Directory.CreateDirectory(imageDirectory);
                    string contentType = file.ContentType.Split('/')[1];
                    string fileName = $"{Guid.NewGuid()}.{contentType}";
                    string fullPath = Path.Combine(imageDirectory, fileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    item.ItemPictureUrl = fileName;
                }
                _itemService.Create(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _itemService.FindById(id.Value);
            if (item == null)
            {
                return NotFound();
            }
            List<Category> categories = _categoryService.GetAll();
            List<SelectListItem> listAItems = new List<SelectListItem>();
            foreach (Category category in categories)
            {
                SelectListItem itemList = new SelectListItem(category.CategoryName, category.ID.ToString());
                listAItems.Add(itemList);
            }
            ViewBag.Categories = listAItems;
            return View(item);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Item item, IFormFile file)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _itemService.Update(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _itemService.FindById(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _itemService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
