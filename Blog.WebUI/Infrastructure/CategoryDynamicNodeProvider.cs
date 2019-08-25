using Blog.Contracts.Services;
using Blog.Model;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Infrastructure
{
    public class CategoryDynamicNodeProvider : DynamicNodeProviderBase
    {
        //private ICategoryService categoryService;

        //public CategoryDynamicNodeProvider(ICategoryService _categoryService)
        //{
        //    categoryService = _categoryService;
        //}

        private ApplicationDbContext db = new ApplicationDbContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodes)
        {
            var returnValue = new List<DynamicNode>();
            foreach (var item in db.Categories)
            {
                DynamicNode node = new DynamicNode();
                node.Title = item.Name;
                node.Key = "Category_" + item.CategoryId;
                node.RouteValues.Add("categoryId", item.CategoryId);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}