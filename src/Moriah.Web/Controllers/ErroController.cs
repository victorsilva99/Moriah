using Microsoft.AspNetCore.Mvc;

namespace Moriah.Web.Controllers;

public class ErroController : Controller
{
    public IActionResult Index(string erro)
    {
        return View(erro);
    }
}