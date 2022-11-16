using GeekShopping.CouponApi.Data.Dtos;

namespace GeekShopping.CouponApi.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCouponCode(string couponCode);
    }
}
