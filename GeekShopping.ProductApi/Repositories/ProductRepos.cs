using AutoMapper;
using GeekShopping.ProductApi.Data.Dtos;
using GeekShopping.ProductApi.Models;
using GeekShopping.ProductApi.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repositories;

public class ProductRepos : IProductRepos
{
    private readonly MyContext context;

    private readonly IMapper mapper;
    public ProductRepos(MyContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    public async Task<ProductDto> Create(ProductDto productDto)
    {
        var product = mapper.Map<Product>(productDto);

        context.Products.Add(product);
        await context.SaveChangesAsync();

        return mapper.Map<ProductDto>(product);
    }

    public async Task<bool> Delete(Guid id)
    {
        try
        {
            Product product = await context.Products.Where(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();
            if (product == null) return false;

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<ProductDto>> FindAll()
    {
        IEnumerable<Product> products = await context.Products.ToListAsync();
        return mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> FindById(Guid id)
    {
        Product product = await context.Products.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        return mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> Update(ProductDto productDto)
    {
        var product = mapper.Map<Product>(productDto);

        context.Products.Update(product);
        await context.SaveChangesAsync();

        return mapper.Map<ProductDto>(product);
    }
}
