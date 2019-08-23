using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model
{
    public class Post
    {
        public int PostId { get; set; }
        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required]
        [MinLength(20, ErrorMessage = "Za mała liczba znaków")]
        [MaxLength(1020, ErrorMessage = "Za duża liczba znaków")]
        [Display(Name = "Treść")]
        public string Content { get; set; }
        public DateTime DateOfAddition { get; set; }
        public string ShortContent { get; set; }
    }
}
