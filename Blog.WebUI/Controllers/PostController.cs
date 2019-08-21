using Blog.Contracts.Services;
using Blog.Model;
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

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }

        [HttpGet]
        public ViewResult AddPost()
        {
            Post post = new Post();
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(Post post)
        {
            string userId = User.Identity.GetUserId();
            if(ModelState.IsValid)
            {
                postService.AddPost(post, userId);
                return RedirectToAction("Index", "Home");
            }
            else return View(post);
        }
    }
}