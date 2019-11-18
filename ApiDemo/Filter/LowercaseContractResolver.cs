using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiDemo.Filter
{
    public class LowercaseContractResolver : Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver
    {
        protected override string ResolveDictionaryKey(string dictionaryKey)
        {
            //var setting = new JsonSerializerSettings
            //              {
            //                  ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            //              };
            //var json = JsonConvert.SerializeObject("", Formatting.None, setting);
            return dictionaryKey;
        }


    }
}
