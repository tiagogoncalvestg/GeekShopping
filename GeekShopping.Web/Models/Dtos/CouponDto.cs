namespace GeekShopping.Web.Models.Dtos;

public class CouponDto
{
    public Guid Id { get; set; }
    public string? CouponCode { get; set; }
    public decimal DiscountAmount { get; set; }
}
