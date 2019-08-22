using Blog.Contracts.Services;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application
{
    public class PostService : IPostService
    {
        private ApplicationDbContext db;

        public PostService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void AddPost(Post post)
        {
            post.DateOfAddition = DateTime.Now;
            post.ShortContent = GetShortContent(post.Content);
            db.Posts.Add(post);
            db.SaveChanges();
        }

        public string GetShortContent(string content)
        {
            string result = content.Substring(0, 40);
            result = result + "...";
            return result;
        }
    }
}
