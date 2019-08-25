using Blog.Contracts.ViewModels;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contracts.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> Categories { get; }
        List<HomeCategoryViewModel> GetAllHomeCategory();
        string GetCategoryName(int categoryId);
        void AddCategory(Category category);
        string GetCategoryDescription(int categoryId);
        Category GetCategory(int categoryId);
    }
}
