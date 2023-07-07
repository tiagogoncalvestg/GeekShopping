using GeekShopping.Web.Models;
using GeekShopping.Web.Services.ClientExtensions;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace GeekShopping.Web.Services;

public class CouponService : ICouponService
{
    private readonly HttpClient client;
    public const string BasePath = "api/coupon";
    public CouponService(HttpClient client)
    {
        this.client = client ?? throw new ArgumentNullException(nameof(client));
    }
    public async Task<CouponDto> GetCoupon(string couponCode, string token)
    {
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        var response = await client.GetAsync($"{BasePath}/{couponCode.ToUpper()}");
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<CouponDto>();
        else 
            return new();
    }
}
