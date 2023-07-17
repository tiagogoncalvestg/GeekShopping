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
    public HttpClient Client { get; set; } = null!;
    public IWebDriver Driver { get; set; } = null!;
}
