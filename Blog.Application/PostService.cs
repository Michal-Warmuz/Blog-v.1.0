using Blog.Contracts.Services;
using Blog.Contracts.ViewModels;
using Blog.Model;
using Blog.Utils;
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
        private ICategoryService categoryService;
        private IUserService userService;

        public PostService(ApplicationDbContext _db, ICategoryService _categoryService, IUserService _userService)
        {
            db = _db;
            categoryService = _categoryService;
            userService = _userService;
        }

        public IEnumerable<Post> Posts { get { return db.Posts; } }
        public void AddPost(Post post)
        {
            //post.DateOfAddition = DateTime.Now;
            post.ShortContent = GetShortContent(post.Content);
            db.Posts.Add(post);
            db.SaveChanges();
        }
        
        public PostsByCategoryViewModel GetPostsByCategoryId(int CategoryId)
        {
            var list = Posts.Where(x => x.CategoryId == CategoryId).OrderByDescending(x => x.DateOfAddition).Take(3);
            var category = categoryService.GetCategory(CategoryId);
            List<HomePostViewModel>  items = new List<HomePostViewModel>();

            foreach (var item in list)
            {
                items.Add(new HomePostViewModel() { PostId = item.PostId, Title = item.Title, ShortContent = item.ShortContent, CategoryName = category.Name });
            }

            PostsByCategoryViewModel model = new PostsByCategoryViewModel();
            model.Posts = items;
            model.CategoryDescription = category.Description;
            model.CategoryName = category.Name;

            return model;
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
        

        public PostDetailsViewModel GetPostDetails(int postId)
        {
            var model = Posts.SingleOrDefault(x => x.PostId == postId);

            var item = new PostDetailsViewModel()
            {
                PostId = model.PostId,
                CategoryName = categoryService.GetCategoryName(model.CategoryId),
                Content = model.Content,
                DateOfAddition = ConvertDate.ConvertRelativeDate(model.DateOfAddition),
                Title = model.Title,
                UserName = userService.GetUserName(model.UserId)
            };

            return item;
        }

        public List<HomePostViewModel> GetNewsPostsByCategoryId(int CategoryId)
        {
            var list = Posts.Where(x => x.CategoryId == CategoryId).OrderByDescending(x => x.DateOfAddition).Take(3);
            
            List<HomePostViewModel> model = new List<HomePostViewModel>();

            foreach (var item in list)
            {
                model.Add(new HomePostViewModel() { PostId = item.PostId, Title = item.Title, ShortContent = item.ShortContent, CategoryName = categoryService.GetCategoryName(item.CategoryId) });
            }
            return model;
        }

        public void EditPost(Post post)
        {
            post.DateOfAddition = DateTime.Now;
            post.ShortContent = GetShortContent(post.Content);
            db.Entry(post).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Post GetPost(int postId)
        {
            var item = db.Posts.SingleOrDefault(x => x.PostId == postId);
            return item;
        }

        public void DeletePost(int postId)
        {
            var post = GetPost(postId);
            db.Posts.Remove(post);
            db.SaveChanges();
        }
    }
}
