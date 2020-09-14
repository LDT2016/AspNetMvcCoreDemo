using System;
using AplDbHelper;

namespace ApiDemo.Models
{
    public class ImprintFormatModel
    {
        #region properties

        public string Description { get; set; }
        public string ImprintAreaCode { get; set; }
        public string ImprintGroup { get; set; }
        public string ImprintRule { get; set; }
        public bool IsDefault { get; set; }
        public bool IsInsideCover => Description.IndexOf("inside", StringComparison.OrdinalIgnoreCase) >= 0;
        public bool IsSuperSized => Description.IndexOf("super-sized", StringComparison.OrdinalIgnoreCase) >= 0;
        public string Key => $"{ImprintAreaCode}-{Location}-{StyleId}".ToUpper();
        public string Location { get; set; }
        public bool LogoOnly { get; set; }
        [Column(Name = "ProcessId")]
        public ProcessTypes ProcessType { get; set; }
        public int Sequence { get; set; }
        public bool ShowOnWeb { get; set; }
        public string StyleId { get; set; }
        public bool SloganAvailable { get; set; }
        public bool VerseAvailable { get; set; }
        public bool AutoDefaultVerse { get; set; }
        public bool SentimentAvailable { get; set; }
        public int MaxColorCount { get; set; }
        public bool HasPms { get; set; }

        #endregion
    }
}
