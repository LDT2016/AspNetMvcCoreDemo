using System.Threading.Tasks;
using ApiDemo.Library.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptController : ControllerBase
    {
        #region fields

        public IAes _aes;

        #endregion

        #region constructors

        /// <summary>
        /// EncryptController
        /// </summary>
        /// <param name="aes"></param>
        public EncryptController(IAes aes)
        {
            _aes = aes;
        }

        #endregion

        #region methods

        /// <summary>
        /// GET: api/Decrypt/plain
        /// </summary>
        /// <param name="plain"></param>
        /// <returns></returns>
        [HttpGet("{plain}")]
        public async Task<string> Get(string plain)
        {
            return await Task.Run(() => _aes.AesEncrypt(plain));
        }

        #endregion
    }
}
