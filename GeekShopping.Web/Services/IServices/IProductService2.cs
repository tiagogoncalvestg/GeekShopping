using GeekShopping.Web.Models;
using Refit;

namespace GeekShopping.Web.Services.IServices;

public interface IProductService2
{
    [Get("/api/Product")]
    Task<IEnumerable<ProductModel>> FindAllProducts();
}
