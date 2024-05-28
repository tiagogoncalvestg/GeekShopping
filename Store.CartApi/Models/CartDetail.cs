namespace Store.CartApi.Models;

public class CartDetail
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}
