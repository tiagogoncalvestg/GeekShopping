namespace GeekShopping.Web.Models
{
    public class CartDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid CartHeaderId { get; set; }
        public CartHeaderViewModel CartHeader { get; set; }
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
