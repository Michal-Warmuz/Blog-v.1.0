using Blog.Contracts.Services;
using Blog.Model;
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

        public CategoryController(ICategoryService  _categoryService)
        {
            categoryService = _categoryService;
        }
        [HttpGet]
        [Authorize(Roles = "Redaktor")]
        public ViewResult AddCategory()
        {
            var category = new Category();
            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Redaktor")]
        public ActionResult DeleteCategory(int categoryId)
        {
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