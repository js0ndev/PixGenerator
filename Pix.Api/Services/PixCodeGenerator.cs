using System.Globalization;
using System.Text;

namespace Pix.Api.Services;

public class PixCodeGenerator
{
    public string Gerar(
        string chavePix,
        string nome,
        string cidade,
        decimal? valor)
    {
        var payload = new StringBuilder();

        payload.Append("000201");

        payload.Append(
            MontarCampo(
                "26",
                MontarCampo(
                    "00",
                    "BR.GOV.BCB.PIX"
                )
                +
                MontarCampo(
                    "01",
                    chavePix
                )
            )
        );

        payload.Append(
            MontarCampo(
                "52",
                "0000"
            )
        );

        payload.Append(
            MontarCampo(
                "53",
                "986"
            )
        );


        if (valor.HasValue)
        {
            payload.Append(
                MontarCampo(
                    "54",
                    valor.Value
                    .ToString(
                        "0.00",
                        CultureInfo.InvariantCulture
                    )
                )
            );
        }


        payload.Append(
            MontarCampo(
                "58",
                "BR"
            )
        );


        payload.Append(
            MontarCampo(
                "59",
                nome.ToUpper()
            )
        );


        payload.Append(
            MontarCampo(
                "60",
                cidade.ToUpper()
            )
        );


        payload.Append("6304");

        payload.Append(
            CalcularCRC(payload.ToString())
        );


        return payload.ToString();
    }


    private string MontarCampo(
        string codigo,
        string valor)
    {
        return codigo
            + valor.Length.ToString("00")
            + valor;
    }


    private string CalcularCRC(string texto)
    {
        ushort crc = 0xFFFF;

        foreach (char c in texto)
        {
            crc ^= (ushort)(c << 8);

            for (int i = 0; i < 8; i++)
            {
                if ((crc & 0x8000) != 0)
                {
                    crc =
                    (ushort)
                    ((crc << 1) ^ 0x1021);
                }
                else
                {
                    crc <<= 1;
                }
            }
        }

        return crc.ToString("X4");
    }
}