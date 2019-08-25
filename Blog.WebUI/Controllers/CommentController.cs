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

            var comment = new Comment()
            {
                PostId = postId
            };
            return View(comment);
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                commentService.AddComment(comment, userId);
                return RedirectToAction("GetPostDetails", "Post", new { postId = comment.PostId });

            }
            return View(comment);
        }

        [HttpGet]
        public PartialViewResult ViewComments(int postId)
        {
            var items = commentService.GetComments(postId);
            return PartialView("_ViewComments", items);
        }


        [HttpGet]
        public ViewResult EditComments(int commentId)
        {
            var items = commentService.FindComment(commentId);
                
            return View(items);
        }

        [HttpPost]
        public ActionResult EditComments(Comment comment)
        {
           if(ModelState.IsValid)
            {
                commentService.EditComment(comment);
                return RedirectToAction("GetPostDetails", "Post", new { postId = comment.PostId });

            }
            else return View(comment);
        }



        [HttpPost]
        public ActionResult DeleteComment(int commentId)
        {
            var post = commentService.FindComment(commentId).PostId;
            commentService.DeleteComment(commentId);
            return RedirectToAction("GetPostDetails", "Post", new { postId =  post} );
        }
    }
}