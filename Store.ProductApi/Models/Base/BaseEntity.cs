using System.ComponentModel.DataAnnotations;

namespace Store.ProductApi.Models.Base;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}
