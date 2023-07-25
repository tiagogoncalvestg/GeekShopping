using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Debugger;

namespace GeekShopping.Tests.PageModels;

public class ProductDetailPage
{
    readonly IWebDriver _driver;
    public ProductDetailPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void SubmitProduct()
    {
        var btnAddToCart = _driver.FindElement(this.btnAddToCart);
        btnAddToCart.Click();
    }

    #region Bys
    public By btnAddToCart = By.XPath("/html/body/div/main/form/div/div/div[3]/div[2]/button");
    public By count = By.Id("Count");
    #endregion
}
