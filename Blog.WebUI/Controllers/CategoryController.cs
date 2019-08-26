using Blog.Contracts.Services;
using Blog.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;
        ILog log = log4net.LogManager.GetLogger(typeof(CategoryController));
        public CategoryController(ICategoryService  _categoryService)
        {
            categoryService = _categoryService;
        }
        [HttpGet]
        [Authorize(Roles = "Redaktor")]
        public ViewResult AddCategory()
        {
            log.Info("Dodanie kategorii");
            var category = new Category();
            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Redaktor")]
        public ActionResult DeleteCategory(int categoryId)
        {
            log.Info("Usunięcie kategorii");
            categoryService.DeleteCategory(categoryId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Redaktor")]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.AddCategory(category);
                return RedirectToAction("Index", "Home");
            }
            else return View(category);
        }
    }
}