using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace GeekShopping.Tests.PageModels;

public class LoginPage
{
    IWebDriver _driver;
    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void CreateAccount()
    {
        _driver.FindElement(By.PartialLinkText("Create Account")).Click();
    }
    public void SetUsername(string userName)
    {
        _driver.FindElement(this.userName).SendKeys(userName);
    }
    public void SetPassword(string password)
    {
        _driver.FindElement(this.password).SendKeys(password);
    }
    public void SubmitLogin()
    {
        _driver.FindElement(btnLogin).Click();
    }

    #region Bys
    public By userName = By.Id("Username");
    public By password = By.Id("Password");
    public By btnLogin = By.XPath("/html/body/div[2]/div/div[2]/div/div/div[2]/form/button[1]");
    #endregion

}
