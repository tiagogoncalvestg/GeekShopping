using GeekShopping.CouponApi.Data.Dtos;
using GeekShopping.CouponApi.Models;
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

    /// <summary>
    /// Obt�m uma resposta status code 200
    /// </summary>
    /// <remarks>Utilizado para teste de disponibilidade do servi�o</remarks>
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
        if (coupon is null)
        {
            coupon = new()
            {
                CouponCode = null
            };
            return Ok(coupon);
        }
        return Ok(coupon);

    }

    [HttpPost("create-coupon")]
    public async Task<ActionResult<CouponDto>> CreateCoupon(Coupon coupon)
    {
        await repos.CreateCoupon(coupon);
        if (coupon is null) return NotFound();
        return Ok(coupon);

    }
}