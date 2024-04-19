using Microsoft.EntityFrameworkCore;
using Store.ProductApi.Infrastructure.Contracts;
using Store.ProductApi.Models;
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
    public async Task<ProductDto> Create(ProductDto productDto)
    {
        Product product = new()
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            Category = productDto.Category,
            ImageUrl = productDto.ImageUrl,
            Description = productDto.Description
        };

        await _context.Products.AddAsync(product);
        _ = _context.SaveChangesAsync();

        return productDto;
    }

    public async Task<bool> Delete(Guid id)
    {
        try
        {
            ProductDto productDto;

            var product = await _context.Products.FirstOrDefaultAsync(o => o.Id == id);
            if (product == null)
                return false;
            else
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<ProductDto> FindById(Guid id)
    {
        ProductDto productDto;

        var product = await _context.Products.FirstOrDefaultAsync(o => o.Id == id);
        if (product == null)
            return new();
        else
            return new()
            {
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

    public async Task<ProductDto> Update(ProductDto productDto)
    {
        Product product = new()
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            Category = productDto.Category,
            ImageUrl = productDto.ImageUrl,
            Description = productDto.Description
        };

        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return productDto;
    }
}
