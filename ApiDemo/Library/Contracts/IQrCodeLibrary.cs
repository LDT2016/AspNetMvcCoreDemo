using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Library.Contracts
{
    public interface IQrCodeLibrary
    {
        /// <summary>
        /// 获取链接地址对应的二维码图像
        /// </summary>

        Task<string> ToQR(string url);

    }
}
