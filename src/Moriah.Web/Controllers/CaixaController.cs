using Microsoft.AspNetCore.Mvc;
using Moriah.Application.Interfaces;
using Moriah.Application.ViewModels;

namespace Moriah.Web.Controllers;

public class CaixaController : Controller
{
    private readonly ICaixaAppService _caixaAppService;

    public CaixaController(ICaixaAppService caixaAppService)
    {
        _caixaAppService = caixaAppService;
    }

    public async Task <IActionResult> Index()
    {
        var registros = await _caixaAppService.ObterTodosAsync();
        return View(registros);
    }
    
    [HttpGet]
    public IActionResult NovoRegistro()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> NovoRegistro(CaixaViewModel caixa)
    {
        await _caixaAppService.Salvar(caixa);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> EditarRegistro([FromRoute] string id)
    {
        var registro = await _caixaAppService.ObterPorIdAsync(id);
        return View(registro);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditarRegistro(CaixaViewModel caixa)
    {
        await _caixaAppService.AtualizarRegistro(caixa);
        return RedirectToAction("Index");
    }
}