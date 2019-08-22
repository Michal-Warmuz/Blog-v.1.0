using Blog.Contracts.Services;
using Blog.Model;
using Blog.WebUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;
        private ICategoryService categoryService;

        public PostController(IPostService _postService, ICategoryService _categoryService)
        {
            postService = _postService;
            categoryService = _categoryService;
        }

        [HttpGet]
        public ViewResult AddPost()
        {

            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            Post post = new Post()
            {
                UserId = User.Identity.GetUserId()
            };
            PostAddViewModel vm = new PostAddViewModel
            {
                Post = post,
                Categories = categoryService.GetAllCategories(),
                
            };
            
            
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(Post post)
        {
        
            if (ModelState.IsValid)
            {
                postService.AddPost(post);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                PostAddViewModel vm = new PostAddViewModel
                {
                    Post = post,
                    Categories = categoryService.GetAllCategories()
                };
                return View(vm);
            }
            
        }
    }
}