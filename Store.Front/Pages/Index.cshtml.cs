using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Front.Helpers.Clients;

namespace Store.Front.Pages;

public class IndexModel : PageModel
{
    private ProductClient _productClient;
    private HttpClient _httpClient = new();

    public IndexModel()
    {

    }

    public async void OnGet()
    {
        _productClient = new(_httpClient);
        Products = await _productClient.ProductAllAsync();
    }

    public ICollection<ProductDto> Products { get; set; }
}
