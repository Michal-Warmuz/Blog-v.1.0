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
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext db;

        public CategoryService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Category> Categories { get { return db.Categories; } }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var postList = db.Posts.Where(x => x.CategoryId == categoryId);
            foreach (var item in postList)
            {
                db.Posts.Remove(item);
            }
            var category = db.Categories.SingleOrDefault(x => x.CategoryId == categoryId);
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public List<HomeCategoryViewModel> GetAllHomeCategory()
        {
            var list = Categories;
            List<HomeCategoryViewModel> model = new List<HomeCategoryViewModel>();

            foreach (var item in list)
            {
                model.Add(new HomeCategoryViewModel() { CategoryId = item.CategoryId, Name = item.Name });
            }
            return model;
        }

        public Category GetCategory(int categoryId)
        {
            return Categories.SingleOrDefault(x => x.CategoryId == categoryId);
        }

        public string GetCategoryDescription(int categoryId)
        {
            string item = db.Categories.SingleOrDefault(x => x.CategoryId == categoryId).Description;
            return item;
        }

        public string GetCategoryName(int categoryId)
        {
            string name = db.Categories.SingleOrDefault(x => x.CategoryId == categoryId).Name;
            return name;
        }
    }
}
