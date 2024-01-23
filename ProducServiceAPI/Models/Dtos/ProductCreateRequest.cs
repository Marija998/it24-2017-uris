using System.ComponentModel.DataAnnotations;

namespace ProductServiceAPI.Models.Dtos
{
    public class ProductCreateRequest
    {
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool isAvailable { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
