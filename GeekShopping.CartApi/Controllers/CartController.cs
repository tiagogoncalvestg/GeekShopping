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

    [HttpGet("find-cart/{id}")]
    public async Task<ActionResult<CartDto>> FindById(Guid id)
    {
        var cart = await repos.FindCartByUserId(id);

        if (cart == null) return NotFound();

        return Ok(cart);
    }

    [HttpPost("add-cart")]
    public async Task<ActionResult<CartDto>> AddCart([FromBody] CartDto cartDto)
    {
        var cart = await repos.SaveOrUpdateCart(cartDto);

        if (cart == null) return NotFound();

        return Ok(cart);
    }

    [HttpPut("update-cart")]
    public async Task<ActionResult<CartDto>> UpdateCart([FromBody] CartDto cartDto)
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
