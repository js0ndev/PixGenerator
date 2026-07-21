using Microsoft.AspNetCore.Mvc;
using Pix.Api.Contracts;
using Pix.Api.Services;

namespace Pix.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PixController : ControllerBase
{
    private readonly PixService _pixService;

    public PixController(PixService pixService)
    {
        _pixService = pixService;
    }


    [HttpPost]
    public IActionResult GerarPix(PixRequest request)
    {
        var resposta = _pixService.GerarPix(request);

        return Ok(resposta);
    }
}