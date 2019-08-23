using Blog.Contracts.Services;
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

        public CommentService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void AddComment(Comment comment,string userId)
        {
            comment.UserId = userId;
            db.Comments.Add(comment);
            db.SaveChanges();
        }
    }
}
