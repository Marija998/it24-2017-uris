using AutoMapper;
using ProductServiceAPI.Models;
using ProductServiceAPI.Models.Dtos;

namespace ProductServiceServiceAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductCreateRequest, Product>();
                config.CreateMap<ProductUpdateRequest, Product>()
                      .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // Ignore null source values
            });
  
            return mappingConfig;
        }
    }
}
