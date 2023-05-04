using Moriah.Web.SeleniumTests.Models.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Moriah.Web.SeleniumTests.Factory;

public static class WebDriverFactory
{
    public static IWebDriver CreateWebDriver(Browser browser, string? pathDriver)
    {
        IWebDriver webDriver = null;

        switch (browser)
        {
            case Browser.Chrome:
                webDriver = new ChromeDriver(pathDriver);
                break;
            case Browser.Edge:
                webDriver = new EdgeDriver(pathDriver);
                break;
            case Browser.Firefox:
                var optionsFirefox = new FirefoxOptions
                {
                    AcceptInsecureCertificates = true
                };
                
                webDriver = new FirefoxDriver(pathDriver, optionsFirefox);
                break;
        }

        return webDriver;
    }
    
    public static IWebDriver CreateWebDriverHeadless(Browser browser, string? pathDriver)
    {
        IWebDriver webDriver = null;

        switch (browser)
        {
            case Browser.Chrome:
                var optionsChrome = new ChromeOptions();
                optionsChrome.AddArgument("--headless");
                
                webDriver = new ChromeDriver(pathDriver, optionsChrome);
                break;
            case Browser.Edge:
                var optionsEdge = new EdgeOptions();
                optionsEdge.AddArgument("--headless");
                
                webDriver = new EdgeDriver(pathDriver, optionsEdge);
                break;
            case Browser.Firefox:
                var optionsFirefox = new FirefoxOptions
                {
                    AcceptInsecureCertificates = true
                };
                optionsFirefox.AddArgument("--headless");
                
                webDriver = new FirefoxDriver(pathDriver, optionsFirefox);
                break;
        }

        return webDriver;
    }
}