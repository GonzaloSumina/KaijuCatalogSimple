
using KaijuCatalogWeb.Domain;
using KaijuCatalogWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace KaijuCatalogWeb.Controllers;

public class KaijuController : Controller
{
    private readonly KaijuService _kaijuService;

    public KaijuController(KaijuService kaijuService)
    {
        _kaijuService = kaijuService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Kaiju(1, "Nuevo Kaiju", 1, 1, "Bajo"));
    }

    [HttpPost]
    public IActionResult Create(
        int id,
        string name,
        double height,
        double weight,
        string threatLevel)
    {
        try
        {
            var kaiju = new Kaiju(id, name, height, weight, threatLevel);
            _kaijuService.Register(kaiju);

            return RedirectToAction("Index", "Home");
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
        }

        return View(new Kaiju(1, "Nuevo Kaiju", 1, 1, "Bajo"));
    }
}
