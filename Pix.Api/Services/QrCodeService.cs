using QRCoder;

namespace Pix.Api.Services;

public class QrCodeService
{
    public string GerarBase64(string texto)
    {
        using var qrGenerator = new QRCodeGenerator();

        using var qrCodeData =
            qrGenerator.CreateQrCode(
                texto,
                QRCodeGenerator.ECCLevel.Q
            );

        using var qrCode =
            new PngByteQRCode(qrCodeData);


        byte[] imagem =
            qrCode.GetGraphic(20);


        return Convert.ToBase64String(imagem);
    }
}