using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contracts.ViewModels
{
    public class PostDetailsViewModel
    {
        public int PostId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string DateOfAddition { get; set; }
        public string UserName { get; set; }
    }
}
