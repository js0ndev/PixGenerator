namespace Pix.Web.Models;

public class PixViewModel
{
    public string Nome { get; set; } = string.Empty;

    public string Cidade { get; set; } = string.Empty;

    public string ChavePix { get; set; } = string.Empty;

    public decimal? Valor { get; set; }


    public string? PixCopiaECola { get; set; }

    public string? QrCodeBase64 { get; set; }
}