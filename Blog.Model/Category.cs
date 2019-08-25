using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [Display(Name= "Nazwa Katwgorii")]
        [MinLength(3, ErrorMessage = "Nazwa kategorii powinniem mieć minimum 3 znaki")]
        [MaxLength(30, ErrorMessage = "Nazwa kategorii powinniem mieć maksimum 30 znaków")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Opis Katwgorii")]
        [MinLength(50,ErrorMessage = "Opis kategorii powinniem mieć minimum 50 znaków")]
        public string Description { get; set; }
    }
}
