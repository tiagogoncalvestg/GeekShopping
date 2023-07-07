using GeekShopping.CouponApi.Data.Dtos;
using GeekShopping.CouponApi.Models;

namespace GeekShopping.CouponApi.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCouponCode(string couponCode);
        Task<bool> CreateCoupon(Coupon coupon);
    }
}
