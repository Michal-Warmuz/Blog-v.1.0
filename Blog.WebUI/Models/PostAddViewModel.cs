using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.WebUI.Models
{
    public class PostAddViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<SelectListItem> CategoryItems
        {
            get
            {
                var allItems = Categories.Select(f => new SelectListItem
                {
                    Value = f.CategoryId.ToString(),
                    Text = f.Name
                });

                return allItems;
            }
        }
    }
}
