using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace GeekShopping.Tests.Models;

public class AppUser
{
    public AppUser()
    {
        Random rand = new();
        FirstName = firstNames[rand.Next(1, firstNames.Count)]; 
        LastName = lastNames[rand.Next(1, lastNames.Count)];
        UserName = userNames[rand.Next(1, lastNames.Count)] + rand.Next(22, 7600);
        Email = $"{UserName}@test.com";
        Password = "Test@r123";
    }

    #region Lista mock de usuários
    List<string> userNames = new() { "Rock", "Great", "Pretty", "Fire", "Personal", "Fast" };
    List<string> firstNames = new() { "Alex", "Erick", "Lisa", "Sun", "Lee", "Jennifer" };
    List<string> lastNames = new() { "C.", "Alpaccinno", "Gonzales", "B. J.", "Luccas", "Richard" };
    #endregion

    public static AppUser GenerateUser()
    {
        return new();
    }

    public static void Login(AppUser appUser, IWebDriver driver)
    {
        driver.FindElement(By.LinkText("Login")).Click();
        driver.FindElement(By.Id("Username")).SendKeys(appUser.UserName);
        driver.FindElement(By.Id("Password")).SendKeys(appUser.Password);

        driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/div[2]/form/button[1]")).Click();
    }

    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
}
