namespace ProductServiceAPI.Models.Dtos
{
    public class ProductUpdateRequest
    {
        public string Name { get; set; }

        // Nullable if not required to update every time
        public double? Price { get; set; } 

        public string Description { get; set; }

        public bool? IsAvailable { get; set; } 

    }
}
