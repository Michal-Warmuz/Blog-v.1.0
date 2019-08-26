using Blog.Contracts.Services;
using Blog.WebUI.Models;
using log4net;
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
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        public HomeController(IUserService _userService, ICategoryService _categoryService, IPostService _postService)
        {
            userService = _userService;
            categoryService = _categoryService;
            postService = _postService;
        }
        public ViewResult Index()
        {
            var list = categoryService.GetAllHomeCategory();
            log.Info("Strona główna");

            return View(list);
        }

        public PartialViewResult NewsPosts(int CategoryId)
        {
            var list = postService.GetNewsPostsByCategoryId(CategoryId);
            log.Info("Najnowsze posty");
            return PartialView("_NewsPosts",list);
        }
    }
}