using GeekShopping.ProductApi.Data.Dtos;
using GeekShopping.ProductApi.Repositories;
using GeekShopping.ProductApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepos repos;

        public ProductController(IProductRepos repos)
        {
            this.repos = repos ?? throw new ArgumentNullException(nameof(repos));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> FindById(Guid id)
        {
            var product = await repos.FindById(id);

            if(product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet("health")]
        public ActionResult Health()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> FindAll()
        {
            var products = await repos.FindAll();

            return Ok(products);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto productDto)
        {
            if (productDto == null) return BadRequest();

            var product = await repos.Create(productDto);

            return Ok(product);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductDto productDto)
        {
            if (productDto == null) return BadRequest();

            var product = await repos.Update(productDto);

            return Ok(product);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var product = await repos.Delete(id);

            if (product == null) return BadRequest();

            return Ok(product);
        }
    }
}
