using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Filter;
using AplDbHelper;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImageController : ControllerBase
    {
        #region fields

        readonly string WebSiteDb = "Data Source=nltc550;initial catalog=APLWebsites;User ID=dev;Password=4Amsterdam;MultipleActiveResultSets=True";

        #endregion

        #region methods

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [HiddenApi]
        public void Delete(int id) { }

        //// GET: api/UserImage
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/UserImage/5
        //[HttpGet("{id}")], means "id" is required
        [HttpGet]
        [HiddenApi]
        public async Task<IActionResult> Get(string cmd, string key)
        {
            if (cmd == "sc")
            {
                var parameters = new Dictionary<string, object>
                                 {
                                     {
                                         "@VendorId", "100010"
                                     },
                                     {
                                         "@StudioItemType", "0"
                                     },
                                     {
                                         "@MaxColorCount", 3
                                     }
                                 };
                var category = await DbHelperStatic.GetResultAsync(WebSiteDb, "prod_GetStockArtworkCategory", parameters);

                var list = category.ToList();

                return Ok(list);
            }

            if (cmd == "st")
            {
                var parameters = new Dictionary<string, object>
                                 {
                                     {
                                         "@VendorId", "100010"
                                     },
                                     {
                                         "@CategoryId", key
                                     }
                                 };
                var category = await DbHelperStatic.GetResultAsync(WebSiteDb, "prod_GetStockArtworkByCategory", parameters);

                var list = category.ToList();

                return Ok(list);
            }

            return Ok("value");
        }

        // POST: api/UserImage
        [HttpPost]
        public void Post([FromBody] string value) { }

        // PUT: api/UserImage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        #endregion
    }
}
