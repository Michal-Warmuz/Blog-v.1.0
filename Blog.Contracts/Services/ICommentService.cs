using Blog.Contracts.ViewModels;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contracts.Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> Comments { get; }
        void AddComment(Comment comment, string userId);
        List<CommentViewModel> GetComments(int postId);
        void DeleteComment(int commentId);
        Comment FindComment(int commentId);
        void EditComment(Comment comment);
    }
}
