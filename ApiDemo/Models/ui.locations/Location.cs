using System.Collections.Generic;

namespace ApiDemo.Models.ui.locations
{
    public class Locations
    {
        #region properties

        public Dictionary<string, Format> Formats { get; set; }
        public Dictionary<string, ImprintGroup> Groups { get; set; }
        public Dictionary<string, string> testDic
        {
            get; set;
        }
        
        #endregion
    }
}
