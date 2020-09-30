﻿using System.Drawing;
using ApiDemo.Services.Interface;
using QRCoder;

namespace ApiDemo.Services
{
    public class QRCodeService : IQRCodeService
    {
        #region  QRCode

        public Bitmap GetQRCode(string plainText, int pixel)
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode(plainText, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCoder.QRCode(qrCodeData);

            var bitmap = qrCode.GetGraphic(pixel);

            return bitmap;
        }

        // add logo/image in qrcode
        public Bitmap GetQRCodeWithLogo(string plainText, int pixel, string logoPath)
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode(plainText, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCoder.QRCode(qrCodeData);

            var bitmap = qrCode.GetGraphic(pixel, Color.Black, Color.White, (Bitmap)Image.FromFile(logoPath), 20, 10);

            return bitmap;
        }

        public Bitmap GetQRCodeWithLogo(string plainText, int pixel, Bitmap centerIcon)
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode(plainText, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCoder.QRCode(qrCodeData);

            var bitmap = qrCode.GetGraphic(pixel, Color.Black, Color.White, centerIcon, 20, 10);

            return bitmap;
        }

        #endregion


        #region Svg QRCode

        public string GetSvgQRCode(string plainText, int pixel)
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode(plainText, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new SvgQRCode(qrCodeData);

            return qrCode.GetGraphic(pixel);
        }
        #endregion
    }
}
