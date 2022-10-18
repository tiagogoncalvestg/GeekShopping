using GeekShopping.ProductApi.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.ProductApi.Models;

public class Product : BaseEntity
{
    public Product()
    {
        Id = Id == null ? Guid.NewGuid() : Id;
    }

    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [Range(1,10000)]
    public decimal Price { get; set; }
    [StringLength(150)]
    public string? Description { get; set; }
    [StringLength(50)]
    public string? CategoryName { get; set; }
    [StringLength(300)]
    public string ImageURL { get; set; }
}
