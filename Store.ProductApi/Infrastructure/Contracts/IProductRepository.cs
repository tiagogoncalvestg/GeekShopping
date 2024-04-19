using Store.ProductApi.Models.Dtos;

namespace Store.ProductApi.Infrastructure.Contracts;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetAll();
    Task<ProductDto> FindById(Guid id);
    // TODO: Alterar para retornar statuscode
    Task<ProductDto> Create(ProductDto productDto);
    Task<ProductDto> Update(ProductDto productDto);
    Task<bool> Delete(Guid id);
}
