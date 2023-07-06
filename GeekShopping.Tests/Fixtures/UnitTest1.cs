using GeekShopping.Tests.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GeekShopping.Tests.Fixtures;

public class Tests
{
    IWebDriver _driver = new ChromeDriver();
    AppUser appUser;

    [OneTimeSetUp]
    public void OneTimeSetUp() 
    {
        appUser = AppUser.GenerateUser();
    }
    [SetUp]
    public void Setup() { }
    [TearDown]
    public void Teardown() { }
    [OneTimeTearDown]
    public void OneTimeTearDown() 
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [Test, Order(100)]
    public void VerifyServices()
    {
        // TODO: rever lógica, aplicar conferência não-local
        // CartService
        _driver.Url = "https://localhost:4445/swagger/v1/swagger.json";
        var tagPre = _driver.FindElement(By.TagName("pre"));
        Assert.IsNotNull(tagPre);
    }

    [Test, Order(200)]
    public void RegisterNewUser()
    {
        _driver.Url = "https://localhost:4430";
        _driver.Manage().Window.Maximize();

        _driver.FindElement(By.LinkText("Login")).Click();
        _driver.FindElement(By.PartialLinkText("Create Account")).Click();

        _driver.FindElement(By.Id("Username")).SendKeys(appUser.UserName);
        _driver.FindElement(By.Id("Email")).SendKeys(appUser.Email);
        _driver.FindElement(By.Id("FirstName")).SendKeys(appUser.FirstName);
        _driver.FindElement(By.Id("LastName")).SendKeys(appUser.LastName);
        _driver.FindElement(By.Id("Password")).SendKeys(appUser.Password);

        var registerBtn = _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/div[2]/form/button[1]"));

        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver; 
        js.ExecuteScript("arguments[0].scrollIntoView(true);", registerBtn);

        //var elem = _driver.FindElement(By.ClassName("something"));
        //_driver.ExecuteScript("arguments[0].scrollIntoView(true);", elem);

        _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/div[2]/form/button[1]")).Click();
    }
}