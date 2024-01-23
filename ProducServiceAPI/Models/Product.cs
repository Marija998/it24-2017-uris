using System.ComponentModel.DataAnnotations;

namespace ProductServiceAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool isAvailable { get; set; }
        [Required]
        public int UserId { get; set; }


    }
}
