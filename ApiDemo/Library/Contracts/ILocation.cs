using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Models.ui.locations;

namespace ApiDemo.Library.Contracts
{
    public interface ILocation
    {
        Task<Locations> GetLocations(string itemId);
    }
}
