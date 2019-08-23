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
        string GetShortContent(string content);
        void AddPost(Post post);
        List<HomePostViewModel> GetNewsPostsByCategoryId(int CategoryId);
        PostDetailsViewModel GetPostDetails(int postId);
    }
}
