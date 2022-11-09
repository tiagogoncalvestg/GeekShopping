using GeekShopping.Web.Models;
using GeekShopping.Web.Models.Dtos;

namespace GeekShopping.Web.Services.IServices;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> FindAllProducts(string token);
    Task<ProductViewModel> FindProductById(Guid id, string token);
    Task<ProductViewModel> CreateProduct(ProductViewModel model, string token);
    Task<ProductViewModel> UpdateProduct(ProductViewModel model, string token);
    Task<bool> DeleteProductById(Guid id, string token);
}
