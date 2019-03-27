using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplDbHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImageController : ControllerBase
    {
        private readonly string WebSiteDb =
            "Data Source=nltc125;initial catalog=APLWebsites;User ID=dev;Password=4Amsterdam;MultipleActiveResultSets=True";

        //// GET: api/UserImage
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/UserImage/5
        //[HttpGet("{id}")], means "id" is required
        [HttpGet]
        public async Task<IActionResult> Get(string cmd, string key)
        {
            if (cmd == "sc")
            {
                var parameters = new Dictionary<string, object>
                {
                    {"@VendorId", "100010"},
                    {"@StudioItemType", "0"},
                    {"@MaxColorCount", 3}
                };
                var category =
                    await DbHelperStatic.GetResultAsync(WebSiteDb,
                        "prod_GetStockArtworkCategory", parameters);

                var list = category.ToList();
                return Ok(list);

            }
            else if (cmd == "st")
            {
                var parameters = new Dictionary<string, object>
                {
                    {"@VendorId", "100010"},
                    {"@CategoryId", key},
                };
                var category =
                    await DbHelperStatic.GetResultAsync(WebSiteDb,
                        "prod_GetStockArtworkByCategory", parameters);

                var list = category.ToList();
                return Ok(list);

            }
            else
            {
                return Ok("value");
            }
        }

        // POST: api/UserImage
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/UserImage/5
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
