using Blog.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Models
{
    public class CommentEditViewModel
    {
        public List<CommentViewModel> Comments { get; set; }
        public string ActiveUser { get; set; }
    }

}