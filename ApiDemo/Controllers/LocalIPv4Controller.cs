using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ApiDemo.Library.Contracts;
using ApiDemo.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    /// <summary>
    /// LocalIPv4Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LocalIPv4Controller : ControllerBase
    {
        public ILocalIPv4Service _localIPv4;

        public LocalIPv4Controller(ILocalIPv4Service localIPv4)
        {
            _localIPv4 = localIPv4;
        }

        // GET: api/LocalIPv4
        [HttpGet]
        public async Task<string> Get()
        {
            return await Task.Run(() => _localIPv4.GetLocalIp());
        }
    }
}
