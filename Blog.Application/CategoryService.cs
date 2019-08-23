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

        public string GetCategoryName(int categoryId)
        {
            string name = db.Categories.SingleOrDefault(x => x.CategoryId == categoryId).Name;
            return name;
        }
    }
}
