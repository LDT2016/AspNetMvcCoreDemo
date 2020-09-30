using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Services.Interface;
using ApiDemo.Models;
using Microsoft.Extensions.Configuration;
using Taylor.Apl.Dapper.Sql;

namespace ApiDemo.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly string _connectionString;
        private readonly ISqlHelper _dbHelper;

        public LocationsService(IConfiguration configuration, ISqlHelper dbHelper)
        {
            _connectionString = configuration.GetConnectionString("AplWebsites");
            _dbHelper = dbHelper;
        }

        public async Task<List<ImprintFormatBO>> GetLocations(string itemid)
        {
            try
            {
                var dbParameters = new Dictionary<string, object>
                                   {
                                       { "@ItemId", itemid }
                                   };
                var result = await _dbHelper.GetEntityAsync<ImprintFormatBO>(_connectionString, "prod_GetImprintFormat", dbParameters);
                var records = result.ToList();

                return records;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public string GetImprintThumbnailFilename(string combination)
        {
            try
            {
                var dbParameters = new Dictionary<string, object>
                                   {
                                       { "@Combination", combination }
                                   };
                var result =  _dbHelper.GetEntityAsync<ImprintThumbnail>(_connectionString, "studio.options_GetImprintThumbnail", dbParameters).Result;
                var records = result.ToList().FirstOrDefault();

                return records?.Filename;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
