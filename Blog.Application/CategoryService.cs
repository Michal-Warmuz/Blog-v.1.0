using Blog.Contracts.Services;
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
        public IEnumerable<Category> GetAllCategories()
        {
            var list = db.Categories;
            return list;
        }

        public List<int> GetAllCategoriesId()
        {
            List<int> list = new List<int>();

            foreach (var item in db.Categories)
            {
                list.Add(item.CategoryId);
            }

            return list;
        }
    }
}
