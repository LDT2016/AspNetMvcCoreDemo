using System.Drawing;

namespace ApiDemo.Services.Interface
{
    public interface IQRCodeService
    {
        Bitmap GetQRCode(string url, int pixel);

        Bitmap GetQRCodeWithLogo(string plainText, int pixel, string logoPath);

        Bitmap GetQRCodeWithLogo(string plainText, int pixel, Bitmap centerIcon);


        string GetSvgQRCode(string plainText, int pixel);

    }
}
