namespace GeekShopping.CartAPI.Data.Dtos
{
    public class CartDetailDto
    {
        public Guid Id { get; set; }
        public Guid CartHeaderId { get; set; }
        public CartHeaderDto CartHeader { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
