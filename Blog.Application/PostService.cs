﻿using Blog.Contracts.Services;
using Blog.Contracts.ViewModels;
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
        private ICategoryService categoryService;
        private IUserService userService;

        public PostService(ApplicationDbContext _db, ICategoryService _categoryService, IUserService _userService)
        {
            db = _db;
            categoryService = _categoryService;
            userService = _userService;
        }
        public void AddPost(Post post)
        {
            post.DateOfAddition = DateTime.Now;
            post.ShortContent = GetShortContent(post.Content);
            db.Posts.Add(post);
            db.SaveChanges();
        }

        public List<HomePostViewModel> GetNewsPostsByCategoryId(int CategoryId)
        {
            var list = db.Posts.Where(x => x.CategoryId == CategoryId).OrderByDescending(x => x.DateOfAddition).Take(3);

            List<HomePostViewModel>  model = new List<HomePostViewModel>();

            foreach (var item in list)
            {
                model.Add(new HomePostViewModel() { PostId = item.PostId, Title = item.Title, ShortContent = item.ShortContent, CategoryName = categoryService.GetCategoryName(item.CategoryId) });
            }
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
            var model = db.Posts.SingleOrDefault(x => x.PostId == postId);

            var item = new PostDetailsViewModel()
            {
                CategoryName = categoryService.GetCategoryName(model.CategoryId),
                Content = model.Content,
                DateOfAddition = model.DateOfAddition,
                Title = model.Title,
                UserName = userService.GetUserName(model.UserId)
            };

            return item;
        }
    }
}
