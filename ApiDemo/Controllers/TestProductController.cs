using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using ApiDemo.Services.Interface;
using ApiDemo.Library.Contracts;
using ApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    /// <summary>
    /// TestProductController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestProductController : ControllerBase
    {
        #region fields

        private readonly ITestProductLib _service;

        #endregion

        #region constructors

        public TestProductController(ITestProductLib service)
        {
            _service = service;
        }

        #endregion

        #region methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productList = await _service.GetTestProduct();
            // order interfaces by speed and filter out down and loopback
            // take first of the remaining
            var firstUpInterface = NetworkInterface.GetAllNetworkInterfaces()
                                                   .OrderByDescending(c => c.Speed)
                                                   .FirstOrDefault(c => c.NetworkInterfaceType != NetworkInterfaceType.Loopback && c.OperationalStatus == OperationalStatus.Up);
            IPAddress firstIpV4Address = null;
            if (firstUpInterface != null)
            {
                var props = firstUpInterface.GetIPProperties();
                // get first IPV4 address assigned to this interface
                firstIpV4Address = props.UnicastAddresses
                                        .Where(c => c.Address.AddressFamily == AddressFamily.InterNetwork)
                                        .Select(c => c.Address)
                                        .FirstOrDefault();
            }

            var testPageModel = new TestPageModel
                                {
                                    ProductList = productList,
                                    ServerIp = firstIpV4Address == null
                                                   ? "IP Not Found"
                                                   : firstIpV4Address.ToString()
                                };

            return Ok(testPageModel);
        }

        #endregion
    }
}
