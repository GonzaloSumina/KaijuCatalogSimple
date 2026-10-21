
using KaijuCatalogWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace KaijuCatalogWeb.Controllers;

public class HomeController : Controller
{
    private readonly KaijuService _kaijuService;

    public HomeController(KaijuService kaijuService)
    {
        _kaijuService = kaijuService;
    }

    public IActionResult Index()
    {
        var kaijus = _kaijuService.GetAll();
        return View(kaijus);
    }
}
