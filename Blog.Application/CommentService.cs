using Blog.Contracts.Services;
using Blog.Contracts.ViewModels;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application
{
    public class CommentService : ICommentService
    {
        private ApplicationDbContext db;
        private IUserService userService;

        public CommentService(ApplicationDbContext _db, IUserService _userService)
        {
            db = _db;
            userService = _userService;
        }

        public IEnumerable<Comment> Comments => db.Comments;

        public void AddComment(Comment comment,string userId)
        {
            comment.UserId = userId;
            db.Comments.Add(comment);
            db.SaveChanges();
        }

        public List<CommentViewModel> GetComments(int postId)
        {
            var list = Comments.Where(x => x.PostId == postId);
            var model = new  List<CommentViewModel>();
            foreach (var item in list)
            {
                model.Add(new CommentViewModel() { CommentId = item.CommentId, Content = item.Content, DateOfAddition = item.DateOfAddition, UserName = userService.GetUserName(item.UserId) });
            }

            return model;
        }
    }
}
