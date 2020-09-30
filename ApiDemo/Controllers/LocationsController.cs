using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Services.Interface;
using ApiDemo.Library.Contracts;
using ApiDemo.Models.ui.locations;
using AutoMapper;
using IBM.Data.DB2.Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private ILocation _location;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        public LocationsController(ILocation location)
        {
            _location = location;
        }

        //// GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        /// <summary>
        /// Get - http://localhost:9008/api/Locations/30303
        /// </summary>
        /// <param name="itemid">30303 (T-shirt), 34939 (multiple groups)</param>
        /// <returns></returns>
        [HttpGet("{itemid}")]
        public async Task<ActionResult> Get(string itemid)
        {
            var locations = await _location.GetLocations(itemid);
            return Ok(locations);
        }

        private static void DDExtHeader()
        {
            
        }
        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
