namespace ShoppingCartService.Models.Dtos
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }
}
