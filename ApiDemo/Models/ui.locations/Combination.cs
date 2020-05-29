using System.Collections.Generic;

namespace ApiDemo.Models.ui.locations
{
    public class Combination
    {
        #region properties

        public string BackgroundFileName { set; get; } = string.Empty;
        public string CombinationsText { set; get; } = string.Empty;
        public List<string> Formats { set; get; } = new List<string>();
        public int Index { set; get; } = 0;
        public bool selected { set; get; }
        public string OptionCharge { set; get; } = string.Empty;
        public string TempNoImprintThumbnailNm { set; get; } = string.Empty;
        public string ThumbnailFilename { set; get; } = string.Empty;

        #endregion
    }
}
