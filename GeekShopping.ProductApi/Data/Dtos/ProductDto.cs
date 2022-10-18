using System.ComponentModel.DataAnnotations;

namespace GeekShopping.ProductApi.Data.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string ImageURL { get; set; }
    }
}
