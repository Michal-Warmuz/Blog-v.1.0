using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contracts.ViewModels
{
    public class HomePostViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string CategoryName { get; set; }
    }
}
