namespace Store.CartApi.Models
{
    public class Sell
    {
        // Esse atributo não deve ser um identificador único
        public Guid SellId { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Amount { get; set; }
    }
}
