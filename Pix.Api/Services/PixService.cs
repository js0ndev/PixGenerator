using Pix.Api.Contracts;

namespace Pix.Api.Services;

public class PixService
{
    private readonly PixCodeGenerator _generator;
    private readonly QrCodeService _qrCodeService;


    public PixService(
        PixCodeGenerator generator,
        QrCodeService qrCodeService)
    {
        _generator = generator;
        _qrCodeService = qrCodeService;
    }


    public PixResponse GerarPix(PixRequest request)
    {
        var brCode = _generator.Gerar(
            request.ChavePix,
            request.Nome,
            request.Cidade,
            request.Valor
        );


        var imagem =
            _qrCodeService.GerarBase64(brCode);


        return new PixResponse
        {
            PixCopiaECola = brCode,
            QrCodeBase64 = imagem
        };
    }
}