using System;
using System.Drawing;
using System.Drawing.Imaging;
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

        public Color GetRandomColor()
        {
            var randomNumFirst = new Random(Guid.NewGuid()
                                                .GetHashCode());

            var randomNumSencond = new Random(Guid.NewGuid()
                                                  .GetHashCode());

            //为了在白色背景上显示，尽量生成深色
            var R = randomNumFirst.Next(256);
            var G = randomNumSencond.Next(256);

            var B = R + G > 400
                        ? 0
                        : 400 - R - G;

            B = B > 255
                    ? 255
                    : B;

            return Color.FromArgb(R, G, B);
        }

        public async Task<string> ToQR(string url, bool colored = false)
        {
            var qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            var qrCode = qrEncoder.Encode(url);

            var drakBrush = colored
                                ? new SolidBrush(GetRandomColor()) : Brushes.Black;

            var lightBrush = Brushes.White;
            var render = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), drakBrush, lightBrush);
            var size = render.SizeCalculator.GetSize(qrCode.Matrix.Width);
            var pic = new Bitmap(size.CodeWidth, size.CodeWidth);
            var g = Graphics.FromImage(pic);
            render.Draw(g, qrCode.Matrix);

            var ms = new MemoryStream();
            pic.Save(ms, ImageFormat.Jpeg);
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
