namespace Store.ProductApi.Models.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? ImageUrl { get; set; }
}
