using GeekShopping.Web.Models;
using GeekShopping.Web.Models.Dtos;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services
{
    public class CouponService : ICouponService
    {
        readonly HttpClient _httpClient;
        public const string BasePath = "api/coupon";
        public CouponService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Models.Dtos.CouponDto> GetCoupon(string couponCode, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{couponCode}");
            return await response.ReadContentAs<Models.Dtos.CouponDto>();


        }
    }
}
