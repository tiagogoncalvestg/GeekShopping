﻿using GeekShopping.CartApi.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model
{
    [Table("cart_detail")]
    public class CartDetail : BaseEntity
    {
        public Guid CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("Count")]
        public int Count { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }
    }
}
