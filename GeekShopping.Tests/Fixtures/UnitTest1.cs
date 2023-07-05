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
        _driver.Url = "https://localhost:4435/account/register";

        _driver.FindElement(By.Id("Username")).SendKeys("UsuárioTeste");
        _driver.FindElement(By.Id("Email")).SendKeys("usuarioteste@test.com");
        _driver.FindElement(By.Id("FirstName")).SendKeys("Usuario");
        _driver.FindElement(By.Id("LastName")).SendKeys("Teste");
        _driver.FindElement(By.Id("Password")).SendKeys("Test@r1234");
        _driver.FindElement(By.XPath("//*[@id=\"RoleName\"]")).Click();
        _driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/div/div/div[2]/form/div[6]/select/option[2]")).Click();

        _driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/div/div/div[2]/form/button[1]")).Click();
    }
}