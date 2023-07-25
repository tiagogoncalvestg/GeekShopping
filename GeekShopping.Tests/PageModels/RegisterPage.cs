using GeekShopping.Tests.Models;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace GeekShopping.Tests.PageModels;

public class RegisterPage
{
    IWebDriver _driver;
    public RegisterPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void FillForm(AppUser appUser)
    {
        _driver.FindElement(By.Id("Username")).SendKeys(appUser.UserName);
        _driver.FindElement(By.Id("Email")).SendKeys(appUser.Email);
        _driver.FindElement(By.Id("FirstName")).SendKeys(appUser.FirstName);
        _driver.FindElement(By.Id("LastName")).SendKeys(appUser.LastName);
        _driver.FindElement(By.Id("Password")).SendKeys(appUser.Password);
    }

    public void SubmitForm()
    {
        _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/div[2]/form/button[1]")).Click();
    }

    #region Bys
    public By btnRegister = By.XPath("/html/body/div[2]/div/div[2]/div/div/div[2]/form/button[1]");
    #endregion
}
