using OpenQA.Selenium;

namespace Moriah.Web.SeleniumTests.Extensions;

public static class WebDriverExtensions
{
    public static void LoadPage(this IWebDriver webDriver, TimeSpan timeToWait, string url)
    {
        webDriver.Manage().Timeouts().PageLoad = timeToWait;
        webDriver.Navigate().GoToUrl(url);
    }

    public static string GetText(this IWebDriver webDriver, By by)
    {
        var webElement = webDriver.FindElement(by);
        return webElement.Text;
    }

    public static void SetText(this IWebDriver webDriver, By by, string text)
    {
        var webElement = webDriver.FindElement(by);
        webElement.SendKeys(text);
    }

    public static void Submit(this IWebDriver webDriver, By by)
    {
        var webElement = webDriver.FindElement(by);
        webElement.Submit();
    }

    public static void Click(this IWebDriver webDriver, By by)
    {
        var webElement = webDriver.FindElement(by);
        webElement.Click();
    }

    public static bool VerifyIfSucess(this IWebDriver webDriver, By by)
    {
        var webElement = webDriver.FindElement(by);
        return webElement != null;
    }
}