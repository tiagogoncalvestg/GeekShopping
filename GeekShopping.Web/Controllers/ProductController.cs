using GeekShopping.Web.Models;
using GeekShopping.Web.Services.ClientExtensions;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GeekShopping.Web.Controllers;

public class ProductController : Controller
{
    private readonly IConfiguration config;

    private readonly IProductService _productService;

    private readonly IProductService2 _productService2;

    private readonly HttpClient httpClient;
    private Client client;


    public ProductController(IProductService productService,
                                IProductService2 productService2, IConfiguration config,
                                HttpClient httpClient)
    {
        this.httpClient = httpClient;
        this.config = config;
        _productService2 = productService2;
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    [Authorize]
    public async Task<IActionResult> ProductIndex()
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        client = new(httpClient, config.GetSection("ServicesUrl").GetSection("ProductAPI").Value);
        //var products = await _productService.FindAllProducts(token);

        //_productService2 aponta para interface não implementada criada para o refit
        //var products = await _productService2.FindAllProducts(token);

        var products = await client.ProductAllAsync(token);
        return View(products);
    }

    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ProductCreate(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.CreateProduct(model, token);
            if (response != null) return RedirectToAction(
                 nameof(ProductIndex));
        }
        return View(model);
    }

    public async Task<IActionResult> ProductUpdate(Guid id)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var model = await _productService.FindProductById(id, token);
        if (model != null) return View(model);
        return NotFound();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ProductUpdate(ProductViewModel model)
    {
        ProductDto productDto = new();
        productDto.Id = model.Id;
        productDto.Name = model.Name;
        productDto.Price = (double)model.Price;
        productDto.CategoryName = model.CategoryName;
        productDto.ImageURL = model.ImageURL;
        productDto.Description = model.Description;

        if (ModelState.IsValid)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.UpdateProduct(model, token);

            //Nswag
            //var response = await client.ProductPUTAsync(productDto, token);
            if (response != null) return RedirectToAction(
                 nameof(ProductIndex));
        }
        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> ProductDelete(Guid id)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var model = await _productService.FindProductById(id, token);
        if (model != null) return View(model);
        return NotFound();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPost]
    public async Task<IActionResult> ProductDelete(ProductViewModel model)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var response = await _productService.DeleteProductById(model.Id, token);
        if (response) return RedirectToAction(
                nameof(ProductIndex));
        return View(model);
    }
}
