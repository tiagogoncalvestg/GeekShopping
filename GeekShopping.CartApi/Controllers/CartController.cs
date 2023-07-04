using GeekShopping.CartApi.Repositories;
using GeekShopping.CartAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartRepository repos;

    public CartController(ICartRepository repos)
    {
        this.repos = repos ?? throw new ArgumentNullException(nameof(repos));
    }

    [HttpGet("find-cart/{userId}")]
    public async Task<ActionResult<CartDto>> FindById(string userId)
    {
        var cart = await repos.FindCartByUserId(userId);

        if (cart == null) return NotFound();

        foreach (var item in cart.CartDetails)
        {
            item.Price = item.Product.Price * item.Count;
        }        

        return Ok(cart);
    }

    [HttpPost("add-cart")]
    public async Task<ActionResult<CartDto>> AddCart(CartDto cartDto)
    {
        var cart = await repos.SaveOrUpdateCart(cartDto);

        if (cart == null) return NotFound();

        return Ok(cart);
    }

    [HttpPost("apply-coupon")]
    public async Task<ActionResult<CartDto>> ApplyCoupon(CartDto cartDto)
    {
        var status = await repos.ApplyCoupon(cartDto.CartHeader.UserId, cartDto.CartHeader.CouponCode);

        if (!status) return NotFound();

        return Ok(status);
    }

    [HttpDelete("remove-coupon/{userId}")]
    public async Task<ActionResult<CartDto>> RemoveCoupon(string userId)
    {
        var status = await repos.RemoveCoupon(userId);

        if (!status) return NotFound();

        return Ok(status);
    }

    [HttpPut("update-cart")]
    public async Task<ActionResult<CartDto>> UpdateCart(CartDto cartDto)
    {
        var cart = await repos.SaveOrUpdateCart(cartDto);

        if (cart == null) return NotFound();

        return Ok(cart);
    }

    [HttpDelete("remove-cart/{id}")]
    public async Task<ActionResult<CartDto>> RemoveCart(Guid id)
    {
        var status = await repos.RemoveFromCart(id);

        if (!status) return BadRequest();

        return Ok(status);
    }
}
