namespace Pix.Api.Contracts;

public class PixRequest
{
    public required string Nome { get; set; }

    public required string Cidade { get; set; }

    public required string ChavePix { get; set; }

    public decimal? Valor { get; set; }

    public string? Descricao { get; set; }

    public string? TxId { get; set; }
}