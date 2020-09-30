using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Services.Interface;
using ApiDemo.Library.Contracts;
using ApiDemo.Services.Interface;

namespace ApiDemo.Library
{
    public class ConfigId : IConfigId
    {
        private readonly IConfigIdService _configService;
        public ConfigId(IConfigIdService configService)
        {
            _configService = configService;
        }

        /// <summary>
        /// GetNewConfigId
        /// </summary>
        /// <returns>NewConfigId</returns>
        public async Task<string> GetNewConfigId()
        {
            var configId = await _configService.GetNewConfigId();

            return "APL" + configId;

        }
    }
}
