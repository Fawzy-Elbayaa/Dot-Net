
using System.ComponentModel.DataAnnotations;
namespace MyShop.Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;   
        public string Description { get; set; } = String.Empty;
        public DateTime CreatedTime { get; set; }= DateTime.Now;
    }
}
