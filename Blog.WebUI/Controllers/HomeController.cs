using Blog.Contracts.Services;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;
        private ICategoryService categoryService;
        private IPostService postService;

        public HomeController(IUserService _userService, ICategoryService _categoryService, IPostService _postService)
        {
            userService = _userService;
            categoryService = _categoryService;
            postService = _postService;
        }
        public ViewResult Index()
        {
            var list = categoryService.GetAllHomeCategory();

            return View(list);
        }

        public PartialViewResult NewsPosts(int CategoryId)
        {
            var list = postService.GetNewsPostsByCategoryId(CategoryId);
            return PartialView("_NewsPosts",list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}