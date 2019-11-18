using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockArtController : ControllerBase
    {
        // GET: api/StockArt
        [HttpGet]
        public ActionResult Get()
        {
            var slogan = new SloganBO();
            var upload = new UploadImageBO();
            //var useimgae = new UserImageBO();

            var jsonObj = new
                          {
                              //useimgae,
                              slogan,
                              upload
                          };
            return Ok(jsonObj);
        }

        // GET: api/StockArt/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StockArt
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/StockArt/5
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
