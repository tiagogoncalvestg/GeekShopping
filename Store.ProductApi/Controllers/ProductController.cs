using Microsoft.AspNetCore.Mvc;
using Store.ProductApi.Infrastructure.Contracts;
using Store.ProductApi.Models.Dtos;

namespace Store.ProductApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    private IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _repository.GetAll();
        if (products == null) NotFound();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> FindById(Guid id)
    {
        var product = await _repository.FindById(id);
        if (product == null) NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(ProductDto productDto)
    {
        if (productDto == null) NotFound();
        var product = await _repository.Create(productDto);

        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult<ProductDto>> Update(ProductDto productDto)
    {
        if (productDto == null) NotFound();
        var product = await _repository.Update(productDto);

        return Ok(product);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        var status = await _repository.Delete(id);
        if (status == false) return NotFound();

        return Ok(status);
    }
}
