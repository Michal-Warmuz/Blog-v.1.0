using Blog.Contracts.Services;
using Blog.Model;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Infrastructure
{
    public class PostDynamicNodeProvider : DynamicNodeProviderBase
    {
        //private IPostService postService;

        //public PostDynamicNodeProvider(IPostService _postService)
        //{
        //    postService = _postService;
        //}
        private ApplicationDbContext db = new ApplicationDbContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodes)
        {
            var returnValue = new List<DynamicNode>();
            foreach (var item in db.Posts)
            {
                DynamicNode node = new DynamicNode();
                node.Title = item.Title;
                node.Key = "Post_" + item.PostId;
                node.ParentKey = "Category_" + item.CategoryId;
                node.RouteValues.Add("postId", item.PostId);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}