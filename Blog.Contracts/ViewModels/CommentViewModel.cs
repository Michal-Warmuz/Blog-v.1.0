using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contracts.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime DateOfAddition { get; set; }
        public string UserId { get; set; }
    }
}
