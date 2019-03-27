using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Interface;
using FiftyOne.Foundation.Mobile.Detection;
using FiftyOne.Foundation.Mobile.Detection.Factories;

namespace ApiDemo.Services
{
    /// <summary>
    /// FiftyOneDegreesService
    /// </summary>
    public class FiftyOneDegreesService: IFiftyOneDegrees
    {
        public ICacheService _cache;

        /// <summary>
        /// FiftyOneDegreesService
        /// </summary>
        /// <param name="cache"></param>
        public FiftyOneDegreesService(ICacheService cache)
        {
            _cache = cache;
            var fileName = @"D:\MobileDeviceDetection\51Degrees.mobi-Premium.dat";
            FiftyOne.Foundation.Mobile.Detection.Entities.DataSet dataSet = StreamFactory.Create(fileName, false);
            _cache.Add("51degrees", dataSet);
        }
    }
}
