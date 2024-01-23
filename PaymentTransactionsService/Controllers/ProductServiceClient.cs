using Newtonsoft.Json;
using System.Net.Http.Json;

namespace TransactionServiceAPI.Controllers
{
    public class ProductServiceClient
    {
        private readonly HttpClient _httpClient;

        public ProductServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"Product/{productId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductDto>(jsonString);
                return product;
            }

            return null; 
        }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
   
    }
}
