using GeekShopping.Web.Models;
using GeekShopping.Web.Services.ClientExtensions;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeekShopping.Web.Controllers;

public class ProductController : Controller
{
    private readonly IConfiguration config;

    private readonly IProductService _productService;

    private readonly IProductService2 _productService2;

    private Client client;


    public ProductController(IProductService productService,
                                IProductService2 productService2, IConfiguration config)
    {
        this.config = config;
        _productService2 = productService2;
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    public async Task<IActionResult> ProductIndex()
    {
        client = new(new HttpClient(), config.GetSection("ServicesUrl").GetSection("ProductAPI").Value);
        //var products = await _productService.FindAllProducts();

        // _productService2 aponta para interface não implementada criada para o refit
        //var products = await _productService2.FindAllProducts();

        var products = await client.ProductAllAsync();
        return View(products);
    }

    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ProductCreate(ProductModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.CreateProduct(model);
            if (response != null) return RedirectToAction(
                 nameof(ProductIndex));
        }
        return View(model);
    }

    public async Task<IActionResult> ProductUpdate(Guid id)
    {
        var model = await _productService.FindProductById(id);
        if (model != null) return View(model);
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ProductUpdate(ProductModel model)
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
            //var response = await _productService.UpdateProduct(model);

            //Nswag
            var response = await client.ProductPUTAsync(productDto);
            if (response != null) return RedirectToAction(
                 nameof(ProductIndex));
        }
        return View(model);
    }

    public async Task<IActionResult> ProductDelete(Guid id)
    {
        var model = await _productService.FindProductById(id);
        if (model != null) return View(model);
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ProductDelete(ProductModel model)
    {
        var response = await _productService.DeleteProductById(model.Id);
        if (response) return RedirectToAction(
                nameof(ProductIndex));
        return View(model);
    }
}
