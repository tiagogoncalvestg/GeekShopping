using GeekShopping.Tests.Helpers;
using GeekShopping.Tests.Helpers.Utils;
using GeekShopping.Tests.Models;
using GeekShopping.Tests.PageModels;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GeekShopping.Tests.Fixtures;

public class Tests
{
    AppUser appUser;
    TestInfrastructure test = null!;

    HomePage homePage;
    CartPage cartPage;
    LoginPage loginPage;
    RegisterPage registerPage;
    ProductDetailPage productDetailPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        test = new();

        cartPage = new(test.Driver);
        homePage = new(test.Driver);
        loginPage = new(test.Driver);
        registerPage = new(test.Driver);
        productDetailPage = new(test.Driver);

        appUser = AppUser.GenerateUser();
    }
    [SetUp]
    public void Setup() { }
    [TearDown]
    public void Teardown() { }
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        test.Driver.Quit();
        test.Driver.Dispose();
    }

    [Test, Order(100)]
    public void VerifyServices()
    {
        // CartService
        var response = test.Client.GetAsync("https://localhost:4445/api/cart/health");
        Assert.That(response.Result.StatusCode == System.Net.HttpStatusCode.OK);

        // CouponService
        response = test.Client.GetAsync("https://localhost:4450/api/coupon/health");
        Assert.That(response.Result.StatusCode == System.Net.HttpStatusCode.OK);

        // ProductService
        response = test.Client.GetAsync("https://localhost:4440/api/product/health");
        Assert.That(response.Result.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test, Order(200)]
    public void RegisterNewUser()
    {
        homePage.GoToPage();
        homePage.Login();

        loginPage.CreateAccount();

        registerPage.FillForm(appUser);
        
        var registerBtn = test.Driver.FindElement(registerPage.btnRegister);
        Util.ScroolToElement(test.Driver, registerBtn);

        registerPage.SubmitForm();

        homePage.Login();
        var userName = test.Driver.FindElement(By.PartialLinkText(appUser.UserName));

        Assert.IsNotNull(userName);
    }

    [Test, Order(300)]
    public void Login()
    {
        homePage.Logout();

        homePage.GoToPage();
        homePage.Login();

        loginPage.SetUsername(appUser.UserName);
        loginPage.SetPassword(appUser.Password);
        loginPage.SubmitLogin();

        var userName = test.Driver.FindElement(By.PartialLinkText(appUser.UserName));

        Assert.IsNotNull(userName);
    }

    [Test, Order(400)]
    public void AddProductToCart()
    {
        // Seleciona um produto
        var product = test.Driver.FindElement(homePage.card4);
        product.Click();

        // Seta a quantidade para 2 e confirma
        test.Driver.FindElement(productDetailPage.count).SendKeys(Keys.Delete + "2");
        productDetailPage.SubmitProduct();

        homePage.ShoppingCart();

        // Verifica a quantidade
        var amount = test.Driver.FindElement(cartPage.cartItem);
        var amountTxt = amount.Text;
        Assert.That(amountTxt == "2");
    }
}