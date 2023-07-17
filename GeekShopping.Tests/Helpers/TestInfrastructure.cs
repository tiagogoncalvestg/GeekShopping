using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GeekShopping.Tests.Helpers;

public class TestInfrastructure
{
    public TestInfrastructure()
    {
        Client = new();
        Driver = new ChromeDriver();
    }
    public HttpClient? Client { get; set; }
    public IWebDriver? Driver { get; set; }
}
