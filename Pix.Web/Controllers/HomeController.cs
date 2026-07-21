using Microsoft.AspNetCore.Mvc;
using Pix.Web.Models;
using Pix.Web.Services;

namespace Pix.Web.Controllers;

public class HomeController : Controller
{
    private readonly PixApiService _pixApiService;


    public HomeController(PixApiService pixApiService)
    {
        _pixApiService = pixApiService;
    }


    [HttpGet]
    public IActionResult Index()
    {
        return View(new PixViewModel());
    }


    [HttpPost]
    public async Task<IActionResult> Index(PixViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }


        var resultado =
            await _pixApiService.GerarPixAsync(model);


        if (resultado == null)
        {
            ModelState.AddModelError(
                "",
                "Erro ao gerar PIX."
            );

            return View(model);
        }


        model.PixCopiaECola =
            resultado.PixCopiaECola;


        model.QrCodeBase64 =
            resultado.QrCodeBase64;


        return View(model);
    }
}