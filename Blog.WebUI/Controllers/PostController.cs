using Blog.Contracts.Services;
using Blog.Model;
using Blog.WebUI.Models;
using log4net;
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
        ILog log = log4net.LogManager.GetLogger(typeof(PostController));

        public PostController(IPostService _postService, ICategoryService _categoryService)
        {
            postService = _postService;
            categoryService = _categoryService;
        }

        [HttpGet]
        [Authorize(Roles = "Redaktor")]
        public ViewResult EditPost(int postId)
        {
            var post = postService.GetPost(postId);

            PostAddViewModel vm = new PostAddViewModel
            {
                Post = post,
                Categories = categoryService.Categories
            };
            log.Info("Edycja Postu");
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Redaktor")]
        public ActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                postService.EditPost(post);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                PostAddViewModel vm = new PostAddViewModel
                {
                    Post = post,
                    Categories = categoryService.Categories
                };
                return View(vm);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Redaktor")]
        public ActionResult DeletePost(int postId)
        {
            postService.DeletePost(postId);
            log.Info("Usunięcie Postu");
            return RedirectToAction("Index", "Home");
            
        }

        [HttpGet]
        [Authorize(Roles = "Redaktor")]
        public ViewResult AddPost()
        {

            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            Post post = new Post()
            {
                UserId = User.Identity.GetUserId()
            };

            log.Info("Dodanie  Postu " + userId);
            PostAddViewModel vm = new PostAddViewModel
            {
                Post = post,
                Categories = categoryService.Categories
                
            };      
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Redaktor")]
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
                    Categories = categoryService.Categories
                };
                return View(vm);
            }
            
        }

        [HttpGet]
        public ViewResult GetPostDetails(int postId)
        {
            log.Info("Pobranie szczegółów postu");
            var item = postService.GetPostDetails(postId);
            return View(item);

        }

        [HttpGet]
        public ViewResult GetPostByCategoryId(int categoryId)
        {
            log.Info("Pobranie postów według kategorii");
            var item = postService.GetPostsByCategoryId(categoryId);
            return View(item);
        }
    }
}