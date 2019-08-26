using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contracts.ViewModels
{
    public class PostsByCategoryViewModel 
    {
        public List<HomePostViewModel> Posts { get; set; }
        public string CategoryDescription { get; set; } 
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
