using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Interface;
using ApiDemo.Services;
using FiftyOne.Foundation.Mobile.Detection;
using FiftyOne.Foundation.Mobile.Detection.Entities;
using FiftyOne.Foundation.Mobile.Detection.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Internal;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImprintController : ControllerBase
    {
        public ICacheService _cache;

        public ImprintController(ICacheService cache, IFiftyOneDegrees degrees)
        {
            _cache = cache;
            //degrees = new FiftyOneDegreesService(cache);
            //FiftyOneDegreesService degrees = new FiftyOneDegreesService(_cache);
        }


        // GET: api/Imprint
        /// <summary>
        /// api/Imprint summary
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var degreeCache = (DataSet)_cache.Get("51degrees");
            var provider = new Provider(degreeCache);
            var clientAgent = Request.Headers["User-Agent"];
            var clientMatch = provider.Match(clientAgent);
            var isMobile = clientMatch["IsMobile"].ToString();
            var isTablet = clientMatch["IsTablet"].ToString();
            return Ok(new { IsMobile = isMobile, IsTablet = isTablet });
        }

        //// GET: api/Imprint/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "get_value";
        //}

        // POST: api/Imprint
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var degreeCache = _cache.Get("51degrees");
            var degreeCacheData = (FiftyOne.Foundation.Mobile.Detection.Entities.DataSet)degreeCache;
            var d = "";
        }

        // PUT: api/Imprint/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var degreeCache = _cache.Get("51degrees");
            var degreeCacheData = (FiftyOne.Foundation.Mobile.Detection.Entities.DataSet)degreeCache;
            var d = "";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var degreeCache = _cache.Get("51degrees");
            var degreeCacheData = (FiftyOne.Foundation.Mobile.Detection.Entities.DataSet)degreeCache;
            var d = "";
        }
    }
}
