using GeekShopping.CouponApi.Data.Dtos;
using GeekShopping.CouponApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CouponApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouponController : ControllerBase
{
    private readonly ICouponRepository repos;

    public CouponController(ICouponRepository repos)
    {
        this.repos = repos;
    }

    [HttpGet("health")]
    public ActionResult Health()
    {
        return Ok();
    }

    [Authorize]
    [HttpGet("{couponCode}")]
    public async Task<ActionResult<CouponDto>> GetCouponByCouponCode(string couponCode)
    {
        var coupon = await repos.GetCouponByCouponCode(couponCode);
        if (coupon is null) return NotFound();
        return Ok(coupon);

    }
}