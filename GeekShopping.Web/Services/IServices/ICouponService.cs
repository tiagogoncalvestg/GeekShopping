using GeekShopping.Web.Models.Dtos;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode, string token);
    }
}
