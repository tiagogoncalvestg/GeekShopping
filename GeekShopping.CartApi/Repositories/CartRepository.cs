using AutoMapper;
using GeekShopping.CartApi.Models.Contexts;
using GeekShopping.CartAPI.Data.Dtos;
using GeekShopping.CartAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Transactions;

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
        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            var header = await context.CartHeaders
                        .FirstOrDefaultAsync(c => c.UserId == userId);
            if (header != null)
            {
                header.CouponCode = couponCode;

                context.CartHeaders.Update(header);
                await context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await context.CartHeaders
                        .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cartHeader != null)
            {
                context.CartDetails.RemoveRange(context.CartDetails.Where(c => c.CartHeaderId.Equals(cartHeader.Id)));

                context.CartHeaders.Remove(cartHeader);
                await context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<CartDto> FindCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await context.CartHeaders
                .FirstOrDefaultAsync(c => c.UserId == userId)
            };

            // Se o CartHeader for null, um é criado na base de dados
            if (cart.CartHeader == null)
            {
                CartHeader cartHeader = new();

                cartHeader.CouponCode = "";
                cartHeader.UserId = userId;

                context.CartHeaders.AddAsync(cartHeader);
                await context.SaveChangesAsync();

                cart.CartHeader = cartHeader;
            }

            cart.CartDetails = context.CartDetails
                .Where(cd => cd.CartHeaderId == cart.CartHeader.Id).Include(c => c.Product);

            return mapper.Map<CartDto>(cart);
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            var header = await context.CartHeaders
                        .FirstOrDefaultAsync(c => c.UserId == userId);
            if (header != null)
            {
                header.CouponCode = null;

                context.CartHeaders.Update(header);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> RemoveFromCart(Guid cartDetailsId)
        {
            try
            {
                CartDetail cartDetail = await context.CartDetails.FirstOrDefaultAsync(c => c.Id == cartDetailsId);

                int total = context.CartDetails.Where(c => c.CartHeaderId == cartDetail.CartHeaderId).Count();
                context.CartDetails.Remove(cartDetail);

                if (total == 1)
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

        //TODO: solucionar falha ao tentar criar carrinho e cartdetail 
        public async Task<CartDto> SaveOrUpdateCart(CartDto cartDto)
        {
            Cart cart = mapper.Map<Cart>(cartDto);

            //Checks if the product is already saved in the database if it does not exist then save
            var product = await context.Products.FirstOrDefaultAsync(
                p => p.Id == cartDto.CartDetails.FirstOrDefault().ProductId);

            if (product == null)
            {
                context.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await context.SaveChangesAsync();
            }

            //Check if CartHeader is null
            var cartHeader = await context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(
                c => c.UserId == cart.CartHeader.UserId);

            if (cartHeader == null)
            {
                //Create CartHeader and CartDetails
                _ = context.CartHeaders.AddAsync(cart.CartHeader);
                await context.SaveChangesAsync();

                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Price = (decimal)cart.CartDetails.FirstOrDefault().Product.Price;

                context.Entry(cart.CartDetails.FirstOrDefault()).State = EntityState.Added;
                context.SaveChanges();
            }
            else
            {
                //If CartHeader is not null
                //Check if CartDetails has same product
                var cartDetail = await context.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    p => p.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
                    p.CartHeaderId == cartHeader.Id);

                if (cartDetail == null)
                {
                    //Create CartDetails new cart....
                    cartDetail = new();
                    int count = cart.CartDetails.FirstOrDefault().Count;
                    decimal price = (decimal)cart.CartDetails.FirstOrDefault().Product.Price;

                    cartDetail.CartHeaderId = cartHeader.Id;
                    cartDetail.ProductId = cart.CartDetails.FirstOrDefault().ProductId;
                    cartDetail.Count = cart.CartDetails.FirstOrDefault().Count;
                    cartDetail.Price = count * price;

                    context.CartDetails.Add(cartDetail);
                    await context.SaveChangesAsync();
                }
                else
                {
                    //Update product count and CartDetails
                    int count = cart.CartDetails.FirstOrDefault().Count;
                    decimal price = (decimal)cart.CartDetails.FirstOrDefault().Product.Price;

                    cartDetail.Product = null;
                    cartDetail.Price = price * count;
                    cartDetail.Count = cart.CartDetails.FirstOrDefault().Count;

                    context.CartDetails.Update(cartDetail);
                    await context.SaveChangesAsync();
                }
            }

            return mapper.Map<CartDto>(cart);
        }
    }
}
