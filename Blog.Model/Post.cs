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
        [MinLength(10, ErrorMessage = "Tytuł powinien mieć minimum 10 znaków")]
        [MaxLength(50, ErrorMessage = "Tytuł powinien mieć maksimum 50 znaków")]
        public string Title { get; set; }
        [Required]
        [MinLength(50, ErrorMessage = "Treść powinna mieć minimum 50 znaków")]
        [Display(Name = "Treść")]
        public string Content { get; set; }
        public DateTime DateOfAddition { get; set; } = DateTime.Now;
        public string ShortContent { get; set; }
    }
}
