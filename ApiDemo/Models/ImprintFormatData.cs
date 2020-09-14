using Taylor.Apl.Dapper;

namespace ApiDemo.Models
{
    public class ImprintFormatData
    {
        #region properties

        public string Description { get; set; }
        public string ImprintAreaCode { get; set; }
        public string ImprintGroup { get; set; }
        public string ImprintRule { get; set; }
        public string IsDefault { get; set; }
        public string Location { get; set; }
        public bool LogoOnly { get; set; }

        [Column(Name = "ProcessId")]
        public ProcessTypes ProcessType { get; set; }

        public int Sequence { get; set; }
        public string ShowOnWeb { get; set; }
        public string StyleId { get; set; }

        #endregion
    }
}
