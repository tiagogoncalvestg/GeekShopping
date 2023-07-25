using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace GeekShopping.Tests.PageModels;

public class HomePage
{
    IWebDriver _driver;
    public HomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void GoToPage()
    {
        _driver.Url = "https://localhost:4430";
        _driver.Manage().Window.Maximize();

    }
    public void Login()
    {
        _driver.FindElement(btnLogin).Click();
    }
    public void Logout()
    {
        _driver.FindElement(btnLogout).Click();
    }
    public void ShoppingCart()
    {
        _driver.FindElement(cartIco).Click();
    }

    #region Bys
    public By card4 = By.XPath("/html/body/div/main/form/div/div[4]/div/div/div/div/div[2]/a");
    public By btnLogin = By.LinkText("Login");
    public By btnLogout = By.LinkText("Logout");
    public By cartIco = By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a/i");
    #endregion
}
