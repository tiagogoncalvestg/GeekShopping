using Microsoft.EntityFrameworkCore;
using Store.ProductApi.Infrastructure.Contracts;
using Store.ProductApi.Models.Dtos;
using AppContext = Store.ProductApi.Infrastructure.Context.AppContext;

namespace Store.ProductApi.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppContext _context;

    public ProductRepository(AppContext context)
    {
        _context = context;
    }
    public Task<ProductDto> Create(ProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductDto> FindById(Guid id)
    {
        ProductDto productDto;

        var product = await _context.Products.FirstOrDefaultAsync(o => o.Id == id);
        if (product == null)
            return new();
        else
            return new(){
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                ImageUrl = product.ImageUrl,
                Description = product.Description
            };
    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        List<ProductDto> productDtos = new();

        var products = await _context.Products.ToListAsync();
        foreach (var product in products)
        {
            productDtos.Add(new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                ImageUrl = product.ImageUrl,
                Description = product.Description
            });
        }

        return productDtos;        
    }

    public Task<ProductDto> Update(ProductDto productDto)
    {
        throw new NotImplementedException();
    }
}
