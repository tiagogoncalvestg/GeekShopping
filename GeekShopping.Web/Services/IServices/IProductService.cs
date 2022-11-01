using GeekShopping.Web.Models;
using GeekShopping.Web.Models.Dtos;

namespace GeekShopping.Web.Services.IServices;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> FindAllProducts(string token);
    Task<ProductModel> FindProductById(Guid id, string token);
    Task<ProductModel> CreateProduct(ProductModel model, string token);
    Task<ProductModel> UpdateProduct(ProductModel model, string token);
    Task<bool> DeleteProductById(Guid id, string token);
}
