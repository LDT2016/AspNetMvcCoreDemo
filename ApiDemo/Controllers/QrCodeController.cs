using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Library.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeController : ControllerBase
    {
        #region fields

        public IQrCodeLibrary _qrcodelib;

        #endregion

        #region constructors

        /// <summary>
        /// DecryptController
        /// </summary>
        /// <param name="aes"></param>
        public QrCodeController(IQrCodeLibrary qrcodelib)
        {
            _qrcodelib = qrcodelib;
        }

        #endregion

        [HttpGet]
        public async Task<string> Get(string code)
        {
            return await Task.Run(() => _qrcodelib.ToQR(code, true));
        }

    }
}
