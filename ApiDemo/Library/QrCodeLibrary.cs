using System;
using System.Buffers.Text;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using ApiDemo.Library.Contracts;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace ApiDemo.Library
{
    public class QrCodeLibrary : IQrCodeLibrary
    {
        #region methods

        public async Task<string> ToQR(string url)
        {
            var qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            var qrCode = qrEncoder.Encode(url);

            var render = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            var size = render.SizeCalculator.GetSize(qrCode.Matrix.Width);
            var pic = new Bitmap(size.CodeWidth, size.CodeWidth);
            var g = Graphics.FromImage(pic);
            render.Draw(g, qrCode.Matrix);

            var ms = new MemoryStream();
            pic.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            var arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            var base64 = Convert.ToBase64String(arr);
            var base64Url = $"data:image/png;base64,{base64}";

            return await Task.Run(() => base64Url);
        }

        #endregion
    }
}
