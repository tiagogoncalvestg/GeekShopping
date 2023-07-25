using OpenQA.Selenium;

namespace GeekShopping.Tests.PageModels;

public class CartPage
{
    readonly IWebDriver _driver;
    public CartPage(IWebDriver driver)
    {
        _driver = driver;   
    }

    #region Bys
    public By cartItem = By.XPath("/html/body/div/main/form/div/div/div[2]/div[2]/div[4]/span");
    #endregion
}
