using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisDemoController : ControllerBase
    {
        public RedisDemoController()
        {
            var dd = "";
        }


        // GET: api/RedisDemo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RedisDemo/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "values";
        }

        // POST: api/RedisDemo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/RedisDemo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
