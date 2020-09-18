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
    public class DecryptController : ControllerBase
    {
        #region fields

        public IAes _aes;

        #endregion

        #region constructors

        /// <summary>
        /// DecryptController
        /// </summary>
        /// <param name="aes"></param>
        public DecryptController(IAes aes)
        {
            _aes = aes;
        }

        #endregion

        #region methods

        /// <summary>
        /// GET: api/Decrypt/cipher
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns></returns>
        [HttpGet("{cipher}")]
        public async Task<string> Get(string cipher)
        {
            return await Task.Run(() => _aes.AesDecrypt(cipher));
        }

        #endregion
    }
}
