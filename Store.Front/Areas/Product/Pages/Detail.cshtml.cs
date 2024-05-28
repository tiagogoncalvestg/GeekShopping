using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Front.Helpers.Clients;

namespace Store.Front.Areas.Product.Pages;

public class DetailModel : PageModel
{
    private ProductClient? _productClient;
    private HttpClient _httpClient = new();


    public async Task<IActionResult> OnGet(string productId)
    {
        _productClient = new(_httpClient);

        Product = await _productClient.ProductGETAsync(new Guid(productId));

        return Page();
    }

    public ProductDto? Product { get; set; }
}
