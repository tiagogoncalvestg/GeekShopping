using OpenQA.Selenium;

namespace GeekShopping.Tests.Helpers.Utils;

public static class Util
{
    public static void ScroolToElement(IWebDriver driver, IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }
}
