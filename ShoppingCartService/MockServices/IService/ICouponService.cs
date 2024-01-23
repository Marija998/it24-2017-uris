

using ShoppingCartService.Models.Dtos;

namespace ShoppingCartService.Services.IService
{
    public interface ICouponService
    {

        Task<CouponDto> GetCoupon(string couponCode);

    }
}
