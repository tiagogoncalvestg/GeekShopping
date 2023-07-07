using AutoMapper;
using GeekShopping.CouponApi.Data.Dtos;
using GeekShopping.CouponApi.Models;
using GeekShopping.CouponApi.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponApi.Repositories;

public class CouponRepository : ICouponRepository
{
    private readonly MyContext context;
    private readonly IMapper mapper;

    public CouponRepository(IMapper mapper, MyContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task<bool> CreateCoupon(Coupon coupon)
    {
        try
        {
            _ = context.Coupons.AddAsync(coupon);
            await context.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    public async Task<CouponDto> GetCouponByCouponCode(string couponCode)
    {
        var coupon = await context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
        return mapper.Map<CouponDto>(coupon);
    }
}
