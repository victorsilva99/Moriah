using Microsoft.Extensions.Configuration;
using Moriah.Web.SeleniumTests.Extensions;
using Moriah.Web.SeleniumTests.Factory;
using Moriah.Web.SeleniumTests.Models.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Moriah.Web.SeleniumTests.Helpers;

public class TelaNovoRegistro
{
    private readonly IConfiguration _configuration;
    private IWebDriver _driver;

    public TelaNovoRegistro(IConfiguration configuration, Browser browser, bool headlessMode = false)
    {
        _configuration = configuration;

        string path = null;
        
        switch (browser)
        {
            case Browser.Firefox:
                path = _configuration.GetSection("Selenium:DriverPathFirefox").Value;
                break;
            case Browser.Chrome:
                path = _configuration.GetSection("Selenium:DriverPathChrome").Value;
                break;
            case Browser.Edge:
                path = _configuration.GetSection("Selenium:DriverPathEdge").Value;
                break;
        }
        
        if(headlessMode)
            _driver = WebDriverFactory.CreateWebDriverHeadless(browser, path);
        else
            _driver = WebDriverFactory.CreateWebDriver(browser, path);
    }

    public void LoadPage()
    {
        _driver.LoadPage(TimeSpan.FromSeconds(5), _configuration.GetSection("Selenium:UrlNovoRegistro").Value);
    }

    public void SetInputTexts(string data, string nota, string moeda, string cartao)
    {
        _driver.SetText(By.Id("Data"), data);
        _driver.SetText(By.Id("Nota"), nota);
        _driver.SetText(By.Id("Moeda"), moeda);
        _driver.SetText(By.Id("Cartao"), cartao);
    }

    public bool VerifyCreation()
    {
        return _driver.VerifyIfSucess(By.ClassName("table"));
    }

    public void Submit()
    {
        _driver.Submit(By.ClassName("btn"));
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.FindElement(By.ClassName("table")) != null) ;
    }

    public void Quit()
    {
        _driver.Quit();
        _driver = null;
    }

    public void TakeAScreenshot(string screen)
    {
        var camera = _driver as ITakesScreenshot;
        camera?.GetScreenshot().SaveAsFile($"{screen}_{Guid.NewGuid()}.png");
    }
}