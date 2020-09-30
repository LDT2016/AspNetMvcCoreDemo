using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Models;

namespace ApiDemo.Services.Interface
{
    public interface ILocationsService
    {
        Task<List<ImprintFormatBO>> GetLocations(string itemid);

        string GetImprintThumbnailFilename(string combination);
    }
}
