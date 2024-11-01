using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Entities.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        public string Name {  get; set; }=string.Empty;
        public string Adderss { get; set; } = string.Empty;
        public string City {  get; set; } = string.Empty;
    }
}
