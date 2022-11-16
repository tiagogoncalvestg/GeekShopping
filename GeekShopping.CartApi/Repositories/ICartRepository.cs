using GeekShopping.CartAPI.Data.Dtos;

namespace GeekShopping.CartApi.Repositories;

public interface ICartRepository
{
    Task<CartDto> FindCartByUserId(string userId);
    Task<CartDto> SaveOrUpdateCart(CartDto cartDto);
    Task<bool> RemoveFromCart(Guid cartDetailsId);
    Task<bool> ApplyCoupon(string userId, string couponCode);
    Task<bool> RemoveCoupon(string userId);
    Task<bool> ClearCart(string userId);
}
