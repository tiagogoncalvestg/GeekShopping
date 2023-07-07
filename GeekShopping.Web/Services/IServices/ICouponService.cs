using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICouponService
    {
        public Task<CouponDto> GetCoupon(string couponCode, string token);
    }
}
