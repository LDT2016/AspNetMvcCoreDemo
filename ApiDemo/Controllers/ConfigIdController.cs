using System.Threading.Tasks;
using ApiDemo.Library.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    /// <summary>
    /// ConfigIdController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigIdController : ControllerBase
    {
        #region fields

        private readonly IConfigId _configId;

        #endregion

        #region constructors

        /// <summary>
        /// ConfigIdController
        /// </summary>
        /// <param name="configId"></param>
        public ConfigIdController(IConfigId configId)
        {
            _configId = configId;
        }

        #endregion

        #region methods

        [HttpGet]
        public async Task<string> Get()
        {
            var configId = await _configId.GetNewConfigId();

            return configId;
        }

        #endregion
    }
}
