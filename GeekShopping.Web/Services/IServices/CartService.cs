using GeekShopping.Web.Models;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;
using System.Reflection;
namespace GeekShopping.Web.Services.IServices;

public class CartService : ICartService
{
    private readonly HttpClient client;
    public const string BasePath = "api/cart";
    public CartService(HttpClient client)
    {
        this.client = client ?? throw new ArgumentNullException(nameof(client));
    }
    public async Task<CartViewModel> AddItemToCart(CartViewModel model, string token)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.PostAsJson($"{BasePath}/add-cart", model);
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<CartViewModel>();

        else throw new Exception("Something went wrong when calling API");

    }

    public async Task<bool> ApplyCoupon(CartViewModel model, string token)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.PostAsJson($"{BasePath}/apply-coupon", model);
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else throw new Exception("Something went wrong when calling API");
    }

    public Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ClearCart(string userId, string token)
    {
        throw new NotImplementedException();
    }

    public async Task<CartViewModel> FindCartByUserId(string userId, string token)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.GetAsync($"{BasePath}/find-cart/{userId}");
        return await response.ReadContentAs<CartViewModel>();

    }

    public async Task<bool> RemoveCoupon(string userId, string token)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.DeleteAsync($"{BasePath}/remove-coupon/{userId}");
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<bool> RemoveFromCart(Guid cartId, string token)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.DeleteAsync($"{BasePath}/remove-cart/{cartId}");
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else throw new Exception("Something went wrong when calling API");

    }

    public async Task<CartViewModel> UpdateCart(CartViewModel model, string token)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.PutAsJson($"{BasePath}/update-cart", model);
        if (response.IsSuccessStatusCode) return await response.ReadContentAs<CartViewModel>();

        else throw new Exception("Something went wrong when calling API");

    }
}
