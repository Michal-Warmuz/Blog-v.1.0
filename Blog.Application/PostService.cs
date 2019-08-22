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

        public IEnumerable<Post> GetNewsPostsByCategoryId(int CategoryId)
        {
            var list = db.Posts.Where(x => x.CategoryId == CategoryId).OrderByDescending(x => x.DateOfAddition).Take(3);
            return list;
        }

        public string GetShortContent(string content)
        {
            string result = "";
            if(content == null)
            {
                return result;
            }
            else
            {
                if (content.Length > 40)
                {
                    result = content.Substring(0, 40);
                    result = result + "...";
                    return result;
                }
                else if (content.Length <= 40)
                {
                    result = content;
                }
                return result;
            }
        }
    }
}
