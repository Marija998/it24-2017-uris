using ShoppingCartService.Models.Dtos;
using ShoppingCartService.Services.IService;
using Stripe;
using Newtonsoft.Json;

namespace ShoppingCartService.Services
{
    public class ItemService : IItemService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ItemService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/api/item");
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ItemDto>>(Convert.ToString(resp.Result));
            }
            return new List<ItemDto>();
        }



    }
}
