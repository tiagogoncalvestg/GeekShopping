using GeekShopping.ProductApi.Data.Dtos;

namespace GeekShopping.ProductApi.Repositories
{
    public interface IProductRepos
    {
        Task<IEnumerable<ProductDto>> FindAll();
        Task<ProductDto> FindById(Guid id);
        Task<ProductDto> Create(ProductDto product);
        Task<ProductDto> Update(ProductDto product);
        Task<bool> Delete(Guid id);
    }
}
