using AutoMapper;
using TransactionServiceAPI.Models;
using TransactionServiceAPI.Models.Dtos;

namespace TransactionServiceAPI
{
    public class MappingConfig : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // Mapping for Account
                config.CreateMap<AccountCreateRequest, Account>()
                    .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => 0)); // Set Balance to 0 by default
                config.CreateMap<AccountUpdateRequest, Account>()
                    .ForMember(dest => dest.Currency, opt => opt.Ignore()); // Ignore Currency for updates

                // Mapping for Transaction
                config.CreateMap<TransactionCreateRequest, Transaction>();


            });

            return mappingConfig;
        }
    }

}
