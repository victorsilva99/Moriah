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

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> SalvarEntradas(CaixaViewModel caixa)
    {
        await _caixaAppService.Salvar(caixa);
        return RedirectToAction("Index");
    }
}