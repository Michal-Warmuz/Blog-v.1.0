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
    public class CommentController : Controller
    {
        private ICommentService commentService;
        private IPostService postService;

        public CommentController(ICommentService _commentService, IPostService _postService)
        {
            commentService = _commentService;
            postService = _postService;
        }
        [HttpGet]
        public ViewResult AddComment(int postId)
        {
            Comment comment = new Comment
            {
                PostId = postId
            };
            return View(comment);
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            if(ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                commentService.AddComment(comment, userId);
                return RedirectToAction("GetPostDetails", "Post", new { postId = comment.PostId });

            }
            return View(comment);
        }
    }
}