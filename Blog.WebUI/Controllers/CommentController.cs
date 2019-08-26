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
    public class CommentController : Controller
    {
        private ICommentService commentService;
        private IPostService postService;
        ILog log = log4net.LogManager.GetLogger(typeof(CommentController));

        public CommentController(ICommentService _commentService, IPostService _postService)
        {
            commentService = _commentService;
            postService = _postService;
        }
        [HttpGet]
        [Authorize(Roles = "User,Redaktor")]
        public ViewResult AddComment(int postId)
        {
            log.Info("Dodanie komentarza");
            var comment = new Comment()
            {
                PostId = postId
            };
            return View(comment);
        }

        [HttpPost]
        [Authorize(Roles = "User, Redaktor")]
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
            log.Info("Widok komentarza");
            var items = commentService.GetComments(postId);

            CommentEditViewModel vm = new CommentEditViewModel();
            vm.Comments = items;
            vm.ActiveUser = User.Identity.GetUserId();
            return PartialView("_ViewComments", vm);
        }


        [HttpGet]
        [Authorize(Roles = "User, Redaktor")]
        public ViewResult EditComments(int commentId)
        {
            log.Info("Edycja komentarza");
            var items = commentService.FindComment(commentId);
                
            return View(items);
        }

        [HttpPost]
        [Authorize(Roles = "User, Redaktor")]
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
        [Authorize(Roles = "User, Redaktor")]
        public ActionResult DeleteComment(int commentId)
        {
            log.Info("Usunięcie  komentarza");
            var post = commentService.FindComment(commentId).PostId;
            commentService.DeleteComment(commentId);
            return RedirectToAction("GetPostDetails", "Post", new { postId =  post} );
        }
    }
}