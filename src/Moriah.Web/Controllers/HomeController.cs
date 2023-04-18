using Microsoft.AspNetCore.Mvc;

namespace Moriah.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}