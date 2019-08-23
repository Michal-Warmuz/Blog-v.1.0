using Blog.Contracts.ViewModels;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contracts.Services
{
    public interface IPostService
    {
        IEnumerable<Post> Posts { get; }
        string GetShortContent(string content);
        void AddPost(Post post);
        List<HomePostViewModel> GetNewsPostsByCategoryId(int CategoryId);
        PostDetailsViewModel GetPostDetails(int postId);
        List<HomePostViewModel> GetPostsByCategoryId(int CategoryId);
        void EditPost(Post post);
        Post GetPost(int postId);
        void DeletePost(int postId);
    }
}
