namespace ShoppingCartService.Models.Dtos
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public CartHeaderDto? CartHeader { get; set; }
        public int ItemId { get; set; }
        public ItemDto? Product { get; set; }
        public int Count { get; set; }
    }
}
