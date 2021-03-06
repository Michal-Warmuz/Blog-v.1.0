﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Treść")]
        public string Content { get; set; }
        public DateTime DateOfAddition { get; set; } = DateTime.Now;
    }
}
