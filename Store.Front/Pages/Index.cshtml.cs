using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Front.Helpers.Clients;

namespace Store.Front.Pages;

public class IndexModel : PageModel
{
    private ProductClient? _productClient;
    private HttpClient _httpClient = new();

    public async Task<IActionResult> OnGet()
    {
        Products = new();
        _productClient = new(_httpClient);

        Products = await _productClient.ProductAllAsync();

        return Page();
    }

    public List<ProductDto>? Products { get; set; }

}
