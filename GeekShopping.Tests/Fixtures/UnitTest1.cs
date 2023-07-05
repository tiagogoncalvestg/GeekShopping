using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GeekShopping.Tests.Fixtures;

public class Tests
{
    IWebDriver _driver = new ChromeDriver();

    [OneTimeSetUp]
    public void OneTimeSetUp() { }
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

    [Test]
    public void VerifyServices()
    {
        //TODO: rever lógica, aplicar conferência não-local
        _driver.Url = "https://localhost:4445/swagger/v1/swagger.json";
        var tagPre = _driver.FindElement(By.TagName("pre"));
        Assert.IsNotNull(tagPre);
    }
}