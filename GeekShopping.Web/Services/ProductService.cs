using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Newtonsoft.Json.Linq;

namespace GeekShopping.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient client;
    public const string BasePath = "api/product";

    public ProductService(HttpClient client)
    {
        this.client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<ProductViewModel> CreateProduct(ProductViewModel model, string token)
    {
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        var response = await client.PostAsJson(BasePath, model);
        if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductViewModel>();

        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<bool> DeleteProductById(Guid id, string token)
    {
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        var response = await client.DeleteAsync($"{BasePath}/{id}");
        if(response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else throw new Exception("Something went wrong when calling API");

    }

    public async Task<IEnumerable<ProductViewModel>> FindAllProducts(string token)
    {
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        var response = await client.GetAsync(BasePath);
        return await response.ReadContentAs<List<ProductViewModel>>();
    }

    public async Task<ProductViewModel> FindProductById(Guid id, string token)
    {
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        var response = await client.GetAsync($"{BasePath}/{id}");
        return await response.ReadContentAs<ProductViewModel>();
    }

    public async Task<ProductViewModel> UpdateProduct(ProductViewModel model, string token)
    {
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        var response = await client.PutAsJson(BasePath, model);
        if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductViewModel>();

        else throw new Exception("Something went wrong when calling API");
    }

}
