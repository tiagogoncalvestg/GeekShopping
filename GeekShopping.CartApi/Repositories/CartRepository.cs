using AutoMapper;
using GeekShopping.CartApi.Models;
using GeekShopping.CartApi.Models.Contexts;
using GeekShopping.CartAPI.Data.Dtos;
using GeekShopping.CartAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartApi.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly MyContext context;
        private IMapper mapper;

        public CartRepository(MyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await context.CartHeaders
                        .FirstOrDefaultAsync(c => c.UserId == userId);
            if(cartHeader != null)
            {
                context.CartDetails.RemoveRange(context.CartDetails.Where(c => c.CartHeaderId.Equals(cartHeader.Id)));
                context.CartHeaders.Remove(cartHeader);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CartDto> FindCartByUserId(Guid userId)
        {
            Cart cart = new()
            {
                CartHeader = await context.CartHeaders.FirstOrDefaultAsync(c => c.UserId.Equals(userId))
            };
            cart.CartDetails = context.CartDetails.Where(c => c.CartHeaderId.Equals(cart.CartHeader.Id))
                .Include(c => c.Product);
            return mapper.Map<CartDto>(cart);
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            return true;
        }

        public async Task<bool> RemoveFromCart(Guid cartDetailsId)
        {
            try
            {
                CartDetail cartDetail = await context.CartDetails.FirstOrDefaultAsync(c => c.Id == cartDetailsId);

                int total = context.CartDetails.Where(c =>c.CartHeaderId == cartDetail.CartHeaderId).Count();
                context.CartDetails.Remove(cartDetail);

                if(total == 1)
                {
                    var cartHeaderToRemove = await context.CartHeaders
                        .FirstOrDefaultAsync(c => c.Id.Equals(cartDetail.CartHeaderId));
                    context.CartHeaders.Remove(cartHeaderToRemove);
                }
                await context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CartDto> SaveOrUpdateCart(CartDto cartDto)
        {
            Cart cart = mapper.Map<Cart>(cartDto);
            var product = await context.Products.FirstOrDefaultAsync(
                p => p.Id.Equals(cartDto.CartDetails.FirstOrDefault().ProductId)
                );

            if (product == null)
            {
                context.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await context.SaveChangesAsync();
            }

            var cartHeader = await context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(
                    c => c.UserId.Equals(cart.CartHeader.UserId)
                );

            if (cartHeader == null)
            {
                context.CartHeaders.Add(cart.CartHeader);
                await context.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = (Guid)cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;
                context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await context.SaveChangesAsync();
            }
            else
            {
                var cartDetail = await context.CartDetails.AsNoTracking()
                    .FirstOrDefaultAsync(
                    p => p.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
                    p.CartHeaderId.Equals(cartHeader.Id));
                if (cartDetail == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = (Guid)cartHeader.Id;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await context.SaveChangesAsync();
                }
                else
                {
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                    cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                    context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await context.SaveChangesAsync();
                }
            }
            return mapper.Map<CartDto>(cart);
        }
    }
}
