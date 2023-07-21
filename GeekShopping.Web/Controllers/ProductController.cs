using GeekShopping.Web.Models;
using GeekShopping.Web.Models.Dtos;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers;

public class ProductController : Controller
{
    private readonly IConfiguration _config;
    private readonly IProductService _productService;


    public ProductController(IProductService productService, IConfiguration config)
    {
        _config = config;
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    [Authorize]
    public async Task<IActionResult> ProductIndex()
    {
        var token = await HttpContext.GetTokenAsync("access_token");

        var products = await _productService.FindAllProducts(token);
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
        productDto.Price = (decimal)model.Price;
        productDto.CategoryName = model.CategoryName;
        productDto.ImageURL = model.ImageURL;
        productDto.Description = model.Description;

        if (ModelState.IsValid)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var response = await _productService.UpdateProduct(model, token);
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
