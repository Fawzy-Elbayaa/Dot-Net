using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Entities.Models
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;


		public string Description { get; set; }=string.Empty;
		[Display(Name ="Image")]
		[ValidateNever]
        public string Img { get; set; }= string.Empty;
		[Required]
        public decimal Price { get; set; } 

		[Required]
        [Display(Name = "Category List")]
        public int CategoryId {  get; set; }
		[ValidateNever]
		public Category category { get; set; }
    }
}
