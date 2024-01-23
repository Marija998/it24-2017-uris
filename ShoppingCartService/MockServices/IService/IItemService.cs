using ShoppingCartService.Models.Dtos;

namespace ShoppingCartService.Services.IService
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetItems();
    }
}
