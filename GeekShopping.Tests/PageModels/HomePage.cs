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
        _driver.FindElement(By.LinkText("Login")).Click();
    }
    public void Logout()
    {
        _driver.FindElement(By.LinkText("Logout")).Click();
    }

    #region Bys
    public By cartIco = By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a/i");
    #endregion
}
