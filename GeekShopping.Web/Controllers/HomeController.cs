using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeekShopping.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductService productService, 
            ICartService cartService)
        {
            _productService = productService;
            _logger = logger;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.FindAllProducts("");
            return View(products);
        }

        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _productService.FindProductById(id, token);
            return View(model);
        }

        [HttpPost]
        [ActionName("Details")]
        [Authorize]
        public async Task<IActionResult> DetailsPost(ProductViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            CartViewModel cart = new()
            {
                CartHeader = new CartHeaderViewModel
                {
                    Id = Guid.NewGuid(),
                    CouponCode = "",
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            CartDetailViewModel cartDetail = new()
            {
                Id = Guid.NewGuid(),
                CartHeader = cart.CartHeader,
                CartHeaderId = cart.CartHeader.Id,
                ProductId = model.Id,
                Product = await _productService.FindProductById(model.Id, token),
                
                Count = model.Count

            };

            List<CartDetailViewModel> cartDetails = new();
            cartDetails.Add(cartDetail);

            cart.CartDetails = cartDetails;

            var response = await _cartService.AddItemToCart(cart, token);
            if(response != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}