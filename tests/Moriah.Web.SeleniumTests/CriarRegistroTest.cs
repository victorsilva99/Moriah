using Microsoft.Extensions.Configuration;
using Moriah.Web.SeleniumTests.Helpers;
using Moriah.Web.SeleniumTests.Models.Enums;

namespace Moriah.Web.SeleniumTests;

public class CriarRegistroTest
{
    private readonly IConfiguration _configuration;

    public CriarRegistroTest()
    {
        var appSettingsPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        
        var builder = new ConfigurationBuilder()
            .SetBasePath(appSettingsPath)
            .AddJsonFile("appsettings.json");

        _configuration = builder.Build();
    }

    [Theory]
    [InlineData(Browser.Chrome, "04-05-2022", "100", "100", "100")]
    [InlineData(Browser.Edge, "05-05-2022", "100", "100", "100")]
    [InlineData(Browser.Firefox, "06-05-2022", "100", "100", "100")]
    public void CriarRegistro_ComSucesso(Browser browser, string data, string nota, string moeda, string maquininha)
    {
        // arrange
        var tela = new TelaNovoRegistro(_configuration, browser, true);
        
        // act
        tela.LoadPage();
        tela.SetInputTexts(data, nota, moeda, maquininha);
        
        tela.TakeAScreenshot($"Tela_Input_{DateTime.Now.ToShortDateString()}");
        
        tela.Submit();
        var sucess = tela.VerifyCreation();
        
        if (sucess)
            tela.TakeAScreenshot($"Listagem_Listagem_Registros_{DateTime.Now.ToShortDateString()}");
        
        tela.Quit();

        // assert
        Assert.True(sucess);
    }
}