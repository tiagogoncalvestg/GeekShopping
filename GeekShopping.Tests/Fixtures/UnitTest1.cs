using GeekShopping.Tests.Helpers;
using GeekShopping.Tests.Helpers.Utils;
using GeekShopping.Tests.Models;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GeekShopping.Tests.Fixtures;

public class Tests
{
    TestInfrastructure? test;
    AppUser appUser;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        test = new();
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
        test.Driver.Url = "https://localhost:4430";
        test.Driver.Manage().Window.Maximize();

        test.Driver.FindElement(By.LinkText("Login")).Click();
        test.Driver.FindElement(By.PartialLinkText("Create Account")).Click();

        test.Driver.FindElement(By.Id("Username")).SendKeys(appUser.UserName);
        test.Driver.FindElement(By.Id("Email")).SendKeys(appUser.Email);
        test.Driver.FindElement(By.Id("FirstName")).SendKeys(appUser.FirstName);
        test.Driver.FindElement(By.Id("LastName")).SendKeys(appUser.LastName);
        test.Driver.FindElement(By.Id("Password")).SendKeys(appUser.Password);

        var registerBtn = test.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/div[2]/form/button[1]"));
        Util.ScroolToElement(test.Driver, registerBtn);

        registerBtn.Click();

        test.Driver.FindElement(By.LinkText("Login")).Click();
        var userName = test.Driver.FindElement(By.PartialLinkText(appUser.UserName));

        Assert.IsNotNull(userName);
    }

    [Test, Order(300)]
    public void Login()
    {
        test.Driver.FindElement(By.LinkText("Logout")).Click();
        test.Driver.Url = "https://localhost:4430";
        test.Driver.FindElement(By.LinkText("Login")).Click();
        test.Driver.FindElement(By.Id("Username")).SendKeys(appUser.UserName);
        test.Driver.FindElement(By.Id("Password")).SendKeys(appUser.Password);
        test.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/div[2]/form/button[1]")).Click();

        var userName = test.Driver.FindElement(By.PartialLinkText(appUser.UserName));

        Assert.IsNotNull(userName);
    }
}