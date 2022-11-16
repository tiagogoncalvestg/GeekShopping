using GeekShopping.CouponApi.Models.Base;

namespace GeekShopping.CouponApi.Data.Dtos
{
    public class CouponDto
    {
        public Guid Id { get; set; }
        public string CouponCode { get; set; }

        public decimal DiscountAmount { get; set; }
    }
}
